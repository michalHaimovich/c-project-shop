using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class OrderImplementation : BlApi.IOrder
    {
        public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isExistingCustomer)
        {
            // העברת תנאי הסינון ישירות לפונקציית ReadAll בשכבת הנתונים
            var relevantSales = dal.Sale.ReadAll(sale =>
                sale.ProductId == productInOrder.ProductId &&
                sale.StartDate <= DateTime.Now && sale.EndDate >= DateTime.Now &&
                productInOrder.Amount >= sale.MinAmountForSale &&
                (isExistingCustomer || sale.IsForAllCustomers));

            // מיון התוצאות והמרה ל-BO בעזרת פונקציית ההרחבה שכתבת
            productInOrder.Sales = relevantSales
                .OrderBy(sale => sale.PricePerUnit)
                .Select(sale => sale.convert()) // שימוש במתודת ההרחבה שלך
                .ToList();
        }

        public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
        {
            // 1. הגדרת משתני עזר פשוטים שיעזרו לנו בחישוב
            int remainingQuantity = productInOrder.Quantity; // כמה פריטים נשאר לנו לחשב
            double totalPrice = 0;                           // המחיר שיצטבר
            List<BO.SaleInProduct> appliedSales = [];        // רשימת המבצעים שהצלחנו לממש

            // 2. אם יש מבצעים, נעבור עליהם אחד אחד
            if (productInOrder.Sales != null)
            {
                foreach (var sale in productInOrder.Sales)
                {
                    // אם הכמות שנשארה לנו קטנה ממה שהמבצע דורש, נדלג למבצע הבא
                    if (remainingQuantity < sale.Quantity)
                    {
                        continue;
                    }

                    // חישוב: כמה פעמים המבצע הזה נכנס בכמות שלנו?
                    int timesUsed = remainingQuantity / sale.Quantity;

                    // חישוב המחיר: (מספר הפעמים שהמבצע הופעל) * (כמות הפריטים במבצע) * (המחיר ליחידה במבצע)
                    totalPrice += timesUsed * sale.Quantity * sale.Price;

                    // עדכון הכמות שנשארה: אנחנו שומרים רק את שארית החלוקה
                    remainingQuantity -= timesUsed * sale.Quantity;

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
            productInOrder.FinalPrice = totalPrice;
            productInOrder.Sales = appliedSales;
        }
        void CalcTotalPrice(BO.Order order)
        {
            order.FinalPrice = order.Products.Select(product => { CalcTotalPriceForProduct(product); return product.FinalPrice; }).Sum();
        }

public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int quantityToAdd)
    {
        // 1. שולפים את המוצר מה-DAL (משתמשים ב-Id)
        var doProduct = _dal.Product.Get(productId);
        if (doProduct == null)
        {
            throw new Exception($"Product with ID {productId} does not exist.");
        }

        // 2. מנסים למצוא את המוצר ברשימת המוצרים של ההזמנה
        var productInOrder = order.Products.FirstOrDefault(p => p.ProductId == productId);

        if (productInOrder != null)
        {
            // 3. המוצר כבר קיים בהזמנה
            int newQuantity = productInOrder.Quantity + quantityToAdd;

            // אם הכמות החדשה אפס או שלילית - מסירים את המוצר מההזמנה
            if (newQuantity <= 0)
            {
                order.Products.Remove(productInOrder);
                CalcTotalPrice(order); // עדכון סך הכל מחיר ההזמנה אחרי המחיקה
                return new List<BO.SaleInProduct>(); // אין מבצעים למוצר שנמחק
            }

            // בודקים שיש מספיק במלאי (Stock)
            if (doProduct.Stock < newQuantity)
            {
                throw new Exception($"Not enough stock. Requested: {newQuantity}, Available: {doProduct.Stock}");
            }

            // מעדכנים את הכמות
            productInOrder.Quantity = newQuantity;
        }
        else
        {
            // 4. המוצר לא קיים בהזמנה
            if (quantityToAdd <= 0)
            {
                throw new Exception("Cannot add a new product with zero or negative quantity.");
            }

            if (doProduct.Stock < quantityToAdd)
            {
                throw new Exception($"Not enough stock. Requested: {quantityToAdd}, Available: {doProduct.Stock}");
            }

            // יצירת מוצר חדש והוספתו להזמנה
            productInOrder = new BO.ProductInOrder
            {
                ProductId = doProduct.Id,
                Name = doProduct.Name,
                BasePrice = doProduct.Price,
                Quantity = quantityToAdd,
                Sales = new List<BO.SaleInProduct>()
            };

            order.Products.Add(productInOrder);
        }

        // --- חישוב מבצעים ומחירים ---

        // 5. בודקים ומעדכנים את המבצעים הרלוונטיים, תוך שימוש ב-IsPreferredClient
        SearchSaleForProduct(productInOrder, order.IsPreferredClient);

        // 6. מחשבים את המחיר למוצר הספציפי כולל מימוש המבצעים
        CalcTotalPriceForProduct(productInOrder);

        // 7. מחשבים ומעדכנים את המחיר הסופי להזמנה כולה
        CalcTotalPrice(order);

        // 8. מחזירים את רשימת המבצעים שמומשו
        return productInOrder.Sales;
    }
        public void DoOrder(BO.Order order)
        {
            // מעבר על כל המוצרים שנמצאים בהזמנה
            foreach (var productInOrder in order.Products)
            {
                // 1. שליפת המוצר העדכני משכבת הנתונים (DAL) כדי לקבל את המלאי המדויק כרגע
                var doProduct = _dal.Product.Get(productInOrder.ProductId);

                if (doProduct == null)
                {
                    throw new Exception($"Product with ID {productInOrder.ProductId} does not exist in the database.");
                }

                // 2. הפחתת הכמות שהוזמנה מהמלאי הקיים
                doProduct.Stock -= productInOrder.Quantity;

                // בדיקת בטיחות (אופציונלי אך מומלץ):
                // לוודא שלא ירדנו למלאי שלילי במקרה ששני לקוחות קנו במקביל
                if (doProduct.Stock < 0)
                {
                    throw new Exception($"Cannot complete order. Not enough stock for product '{doProduct.Name}'.");
                }

                // 3. שליחת האובייקט המעודכן חזרה ל-DAL כדי לשמור את השינוי
                // ההנחה כאן היא שיש פונקציית Update ב-DAL שמקבלת את האובייקט ומעדכנת אותו
                dal.Product.Update(doProduct);
            }

        }
    }
}
