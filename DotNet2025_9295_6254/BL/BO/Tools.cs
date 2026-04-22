using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T obj)
        {
            // 1. תנאי עצירה למקרה שאין ערך
            if (obj == null) return "null";

            // 2. טיפול באוספים (רשימות/מערכים) - נכנסים לעומק הרשימה
            if (obj is IEnumerable enumerable && obj is not string)
            {
                var items = enumerable.Cast<object>().Select(item => item.ToStringProperty());
                return $"[{string.Join(", ", items)}]";
            }

            Type type = obj.GetType();

            // 3. טיפול בסוגים בסיסיים (מספרים, בוליאני, מחרוזות)
            if (type.IsPrimitive || type.IsValueType || type == typeof(string))
            {
                return type == typeof(string) ? $"\"{obj}\"" : obj.ToString();
            }

            // 4. חקירת האובייקט (Reflection) - שליפת כל התכונות הציבוריות
            var properties = type.GetProperties();

            // 5. הרכבת המחרוזת: שם התכונה והערך שלה
            var propStrings = properties.Select(prop =>
            {
                object value = prop.GetValue(obj);
                // קריאה חוזרת למתודה כדי לטפל במקרה שהערך הוא בעצמו אובייקט מורכב או רשימה
                string valueString = value.ToStringProperty();
                return $"{prop.Name}: {valueString}";
            });

            // עטיפת התוצאה בסוגריים מסולסלים כדי להראות שזה אובייקט
            return $"{{ {string.Join(", ", propStrings)} }}";
        }

        public static BO.Client convert(this DO.Customer customer)
        {
            return new BO.Client
            {
                Id = customer.id,
                Name = customer.customer_name,
                Address = customer.customer_adress,
                Phone = customer.customer_phon
            };
        }

        public static BO.Product convert(this DO.Product product)
        {
            return new BO.Product
            {
                Id = product.id,
                Name = product.product_name,
                category = (ElectricalApplianceCategory)product.category,
                Price = product.price,
                Stock = product.amount_in_stock,
                Sales = new List<SaleInProduct>()
            };
        }

        public static BO.Sale convert(this DO.Sale sale)
        {
            return new BO.Sale
            {
                Id = sale.id,
                ProductId = sale.product_id,
                amount = sale.amount_to_sale,
                count_to_sale = sale.count_to_sale,
                to_club = sale.to_club,
                start_date = sale.start_date,
                end_date = sale.end_date

            };
        }

        public static DO.Customer convert(this BO.Client client)
        {
            return new DO.Customer
            {
                id = client.Id,
                customer_name = client.Name,
                customer_adress = client.Address,
                customer_phon = client.Phone
            };
        }

        public static DO.Product convert(this BO.Product product)
        {
            return new DO.Product
            {
                id = product.Id,
                product_name = product.Name,
                category = (DO.ElectricalApplianceCategory)product.category,
                price = product.Price,
                amount_in_stock = product.Stock
            };
        }
        public static DO.Sale convert(this BO.Sale sale)
        {
            return new DO.Sale
            {
                id = sale.Id,
                product_id = sale.ProductId,
                amount_to_sale = sale.amount,
                count_to_sale = sale.count_to_sale,
                to_club = sale.to_club,
                start_date = sale.start_date,
                end_date = sale.end_date
            };
        }
    }
}
