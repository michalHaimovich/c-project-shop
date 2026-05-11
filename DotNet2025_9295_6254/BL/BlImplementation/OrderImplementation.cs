using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BlApi;
using BO;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        IDal _dal = DalApi.Factory.Get;  
        public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isClubMember)
        {
            var relevantSales = _dal.Sale.ReadAll(sale =>
                sale.product_id == productInOrder.ProductId &&
                sale.start_date <= DateTime.Now && sale.end_date >= DateTime.Now &&
                productInOrder.Quantity_in_order >= sale.amount_to_sale &&
                sale.count_to_sale > 0 &&
                (isClubMember ||  !sale.to_club ));

            productInOrder.Sales = relevantSales.OrderBy(sale => sale.amount_to_sale).Select(sale => sale.convert()).Select(s=> new SaleInProduct() { IsForAllClients = !s.to_club ,Price_per_one = s.cost_per_one, Amount_to_sale = s.amount_to_sale , SaleId = s.Id }).ToList();
        }

        public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
        {
            // 1. הגדרת משתני עזר פשוטים שיעזרו לנו בחישוב
            int remainingQuantity = productInOrder.Quantity_in_order; // כמה פריטים נשאר לנו לחשב
            double totalPrice = 0;                           // המחיר שיצטבר
            List<BO.SaleInProduct> appliedSales = [];        // רשימת המבצעים שהצלחנו לממש

            // 2. אם יש מבצעים, נעבור עליהם אחד אחד
            if (productInOrder.Sales != null)
            {
                foreach (var sale in productInOrder.Sales)
                {
                    // אם הכמות שנשארה לנו קטנה ממה שהמבצע דורש, נדלג למבצע הבא
                    if (remainingQuantity < sale.Amount_to_sale)
                    {
                        continue;
                    }

                    // חישוב: כמה פעמים המבצע הזה נכנס בכמות שלנו?
                    int timesUsed = remainingQuantity / sale.Amount_to_sale;

                    // חישוב המחיר: (מספר הפעמים שהמבצע הופעל) * (כמות הפריטים במבצע) * (המחיר ליחידה במבצע)
                    totalPrice += timesUsed * sale.Amount_to_sale * sale.Price_per_one;

                    // עדכון הכמות שנשארה: אנחנו שומרים רק את שארית החלוקה
                    remainingQuantity -= timesUsed * sale.Amount_to_sale;

                    // מוסיפים את המבצע לרשימת המבצעים שמומשו
                    appliedSales.Add(sale);

                    // אם סיימנו לחשב את כל הפריטים, אפשר לצאת מהלולאה
                    if (remainingQuantity == 0)
                    {
                        break;
                    }
                }
            }

            // 3. אם נשארו פריטים שלא נכנסו לאף מבצע, נוסיף אותם במחיר הבסיסי הרגיל
            totalPrice += remainingQuantity * productInOrder.BasePrice;

            // 4. עדכון האובייקט עם התוצאות הסופיות
            productInOrder.FinalPrice_in_total = totalPrice;
            productInOrder.Sales = appliedSales;
        }
       
        public void CalcTotalPrice(Order order)
        {
            order.FinalPrice = order.Products.Select(product => { CalcTotalPriceForProduct(product); return product.FinalPrice_in_total; }).Sum();
        }

        public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quantityToAdd)
    {
        // 1. שולפים את המוצר מה-DAL (משתמשים ב-Id)
        var doProduct = _dal.Product.Read(productId);
        if (doProduct == null)
        {
            throw new Exception($"Product with ID {productId} does not exist.");
        }

        // 2. מנסים למצוא את המוצר ברשימת המוצרים של ההזמנה
        var productInOrder = order.Products.FirstOrDefault(p => p.ProductId == productId);

        if (productInOrder != null)
        {
            // 3. המוצר כבר קיים בהזמנה
            int newQuantity = productInOrder.Quantity_in_order + quantityToAdd;

            // אם הכמות החדשה אפס או שלילית - מסירים את המוצר מההזמנה
            if (newQuantity <= 0)
            {
                order.Products.Remove(productInOrder);
                CalcTotalPrice(order); // עדכון סך הכל מחיר ההזמנה אחרי המחיקה
                return new List<BO.SaleInProduct>(); // אין מבצעים למוצר שנמחק
            }

            // בודקים שיש מספיק במלאי (Stock)
            if (doProduct.amount_in_stock < newQuantity)
            {
                throw new Exception($"Not enough stock. Requested: {newQuantity}, Available: {doProduct.amount_in_stock}");
            }

            // מעדכנים את הכמות
            productInOrder.Quantity_in_order = newQuantity;
        }
        else
        {
            // 4. המוצר לא קיים בהזמנה
            if (quantityToAdd <= 0)
            {
                throw new Exception("Cannot add a new product with zero or negative quantity.");
            }

            if (doProduct.amount_in_stock < quantityToAdd)
            {
                throw new Exception($"Not enough stock. Requested: {quantityToAdd}, Available: {doProduct.amount_in_stock}");
            }

            // יצירת מוצר חדש והוספתו להזמנה
            productInOrder = new BO.ProductInOrder
            {
                ProductId = doProduct.id,
                Name = doProduct.product_name,
                BasePrice = doProduct.price,
                Quantity_in_order = quantityToAdd,
                Sales = new List<BO.SaleInProduct>()
            };

            order.Products.Add(productInOrder);
        }

        // --- חישוב מבצעים ומחירים ---

        // 5. בודקים ומעדכנים את המבצעים הרלוונטיים, תוך שימוש ב-IsPreferredClient
        SearchSaleForProduct(productInOrder, order.IsPreferredClient);
        Console.WriteLine(" after serch sales"+productInOrder.Sales.ToArray());
        // 6. מחשבים את המחיר למוצר הספציפי כולל מימוש המבצעים
        CalcTotalPriceForProduct(productInOrder);
        Console.WriteLine(" after calc total price for product" + productInOrder.FinalPrice_in_total);
        // 7. מחשבים ומעדכנים את המחיר הסופי להזמנה כולה
        CalcTotalPrice(order);

        // 8. מחזירים את רשימת המבצעים שמומשוq
        return productInOrder.Sales;
    }
        
        public void DoOrder(BO.Order order)
        {
            // מעבר על כל המוצרים שנמצאים בהזמנה
            foreach (var productInOrder in order.Products)
            {
                // 1. שליפת המוצר העדכני משכבת הנתונים (DAL) כדי לקבל את המלאי המדויק כרגע
                var doProduct = _dal.Product.Read(productInOrder.ProductId);

                if (doProduct == null)
                {
                    throw new Exception($"Product with ID {productInOrder.ProductId} does not exist in the database.");
                }

                if (doProduct.amount_in_stock < productInOrder.Quantity_in_order)
                {
                    throw new Exception($"Cannot complete order. Not enough stock for product '{doProduct.product_name}'.");
                }

                // 3. שליחת האובייקט המעודכן חזרה ל-DAL כדי לשמור את השינוי
                // ההנחה כאן היא שיש פונקציית Update ב-DAL שמקבלת את האובייקט ומעדכנת אותו
            // הפחתת ספירת השימושים במבצעים בהתאם לכמויות שהוחלו
            if (productInOrder.Sales != null && productInOrder.Sales.Count > 0)
            {
                int remainingQuantityForSales = productInOrder.Quantity_in_order;
                // Sales were stored ordered by Amount_to_sale in CalcTotalPriceForProduct
                foreach (var appliedSale in productInOrder.Sales)
                {
                    if (remainingQuantityForSales < appliedSale.Amount_to_sale)
                        continue;

                    int timesUsed = remainingQuantityForSales / appliedSale.Amount_to_sale;
                    if (timesUsed <= 0)
                        continue;

                    try
                    {
                        var doSale = _dal.Sale.Read(appliedSale.SaleId);
                        if (doSale != null)
                        {
                            // reduce the available count (count_to_sale) by the number of times the sale was used
                            int newCount = doSale.count_to_sale - timesUsed;
                            if (newCount < 0) newCount = 0;
                            _dal.Sale.Update(doSale with { count_to_sale = newCount });
                        }
                    }
                    catch
                    {
                        // ignore DAL errors for sale update to not block order completion
                    }

                    remainingQuantityForSales -= timesUsed * appliedSale.Amount_to_sale;
                    if (remainingQuantityForSales <= 0)
                        break;
                }
            }

            _dal.Product.Update(doProduct with { amount_in_stock = doProduct.amount_in_stock - productInOrder.Quantity_in_order });
            }

        }

    }
}
