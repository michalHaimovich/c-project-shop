using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLTest
{
    /// <summary>
    /// תוכנית בדיקה אינטראקטיבית ליצירת הזמנות בשכבת הלוגיקה (BL)
    /// מדמה זרימת עסקית שלמה: בחירת לקוח → הוספת מוצרים → ביצוע הזמנה
    /// </summary>
    class Program
    {
        // שדה סטטי לממשק הלוגיקה הראשי
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        // משתנים גלובליים לאחזור נתונים
        private static List<BO.Client> allClients = new List<BO.Client>();
        private static List<BO.Product> allProducts = new List<BO.Product>();

        static void Main(string[] args)
        {
            try
            {
                // אתחול נתונים מ-DAL
                DalTest.Initializatation.initialize();
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("✅ נתונים אותחלו בהצלחה מ-DalTest\n");

                // טעינת לקוחות ומוצרים
                LoadData();

                // תפריט ראשי
                ShowMainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ שגיאה כללית: {ex.Message}");
            }
        }

        /// <summary>
        /// טעינת נתונים גלוביים (לקוחות ומוצרים)
        /// </summary>
        private static void LoadData()
        {
            try
            {
                allClients = s_bl.IClient.GetAll().ToList();
                allProducts = s_bl.IProduct.GetAll().ToList();

                Console.WriteLine($"📦 נטענו {allProducts.Count} מוצרים");
                Console.WriteLine($"👥 נטענו {allClients.Count} לקוחות\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ שגיאה בטעינת נתונים: {ex.Message}");
            }
        }

        /// <summary>
        /// תפריט ראשי של התוכנית
        /// </summary>
        private static void ShowMainMenu()
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║      תפריט ראשי - ניהול הזמנות        ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("1. צור הזמנה חדשה");
                Console.WriteLine("2. בדיקות מומחה (כפי שהיו)");
                Console.WriteLine("0. יציאה מהתוכנית");
                Console.WriteLine("────────────────────────────────────────");
                Console.Write("בחר אפשרות: ");

                string choice = Console.ReadLine() ?? "0";

                switch (choice)
                {
                    case "1":
                        CreateNewOrder();
                        break;
                    case "2":
                        ShowExpertTestsMenu();
                        break;
                    case "0":
                        exitProgram = true;
                        Console.WriteLine("👋 התוכנית הופסקה. להתראות!");
                        break;
                    default:
                        Console.WriteLine("❌ בחירה לא תקינה, אנא בחר שוב");
                        break;
                }
            }
        }

        /// <summary>
        /// זרימה שלמה של יצירת הזמנה: בחירת לקוח → הוספת מוצרים → ביצוע
        /// </summary>
        private static void CreateNewOrder()
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║        יצירת הזמנה חדשה        ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n");

                // שלב 1: בחירת לקוח
                var selectedClient = SelectClient();
                if (selectedClient == null)
                    return; // ביטול

                // שלב 2: יצירת הזמנה ריקה
                var order = new Order
                {
                    IsPreferredClient = selectedClient.IsClubMember,
                    Products = new List<ProductInOrder>(),
                    FinalPrice = 0
                };

                Console.WriteLine($"\n✅ בחרת לקוח: {selectedClient.Name} (ID: {selectedClient.Id})");
                Console.WriteLine("────────────────────────────────────────\n");

                // שלב 3: הוספת מוצרים
                AddProductsToOrder(order);

                // שלב 4: בדיקה אם יש מוצרים
                if (order.Products.Count == 0)
                {
                    Console.WriteLine("⚠️  ההזמנה ריקה - לא בוצעה.");
                    return;
                }

                // שלב 5: ביצוע ההזמנה
                ExecuteOrder(order, selectedClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ שגיאה ביצירת הזמנה: {ex.Message}");
            }
        }

        /// <summary>
        /// בחירת לקוח מרשימה
        /// </summary>
        private static BO.Client SelectClient()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("╔─ בחר לקוח ─────────────────────────────╗");
                    Console.WriteLine("║ רשימת לקוחות זמינים:         ║");
                    Console.WriteLine("╚────────────────────────────────────────╝\n");

                    // הצג רשימת לקוחות
                    for (int i = 0; i < allClients.Count; i++)
                    {
                        var client = allClients[i];
                        Console.WriteLine($"{i + 1,2}. {client.Name} | ID: {client.Id} | טלפון: {client.Phone ?? "N/A"}");
                    }

                    Console.WriteLine($"\n{allClients.Count + 1,2}. ביטול");
                    Console.WriteLine("────────────────────────────────────────");
                    Console.Write("בחר מספר לקוח: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > allClients.Count + 1)
                    {
                        Console.WriteLine("❌ בחירה לא תקינה");
                        continue;
                    }

                    if (choice == allClients.Count + 1)
                    {
                        Console.WriteLine("🚫 ביטול בחירת לקוח");
                        return null;
                    }

                    return allClients[choice - 1];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ שגיאה: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// תפריט הוספת מוצרים להזמנה
        /// </summary>
        private static void AddProductsToOrder(Order order)
        {
            bool finishAdding = false;

            while (!finishAdding)
            {
                try
                {
                    Console.WriteLine("\n╔─ הוספת מוצרים ─────────────────────────╗");
                    Console.WriteLine("║ רשימת מוצרים זמינים:        ║");
                    Console.WriteLine("╚────────────────────────────────────────╝\n");

                    
                    // הצג רשימת מוצרים
                    foreach (var prod in allProducts)
                    {
                        Console.WriteLine($"ID: {prod.Id} | שם: {prod.Name} | מחיר: ${prod.Price} | מלאי: {prod.Stock}");
                    }

                    Console.WriteLine("\n────────────────────────────────────────");
                    Console.WriteLine("• הקלד ID של מוצר להוסיף");
                    Console.WriteLine("• הקלד 0 לסיום הוספת מוצרים");
                    Console.Write("בחר: ");

                    if (!int.TryParse(Console.ReadLine(), out int productId))
                    {
                        Console.WriteLine("❌ קלט לא תקין");
                        continue;
                    }

                    if (productId == 0)
                    {
                        finishAdding = true;
                        break;
                    }

                    // בדוק אם המוצר קיים
                    var product = allProducts.FirstOrDefault(p => p.Id == productId);
                    if (product == null)
                    {
                        Console.WriteLine($"❌ מוצר עם ID {productId} לא קיים");
                        continue;
                    }

                    // קבל כמות
                    Console.Write($"הקלד כמות להוספה: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.WriteLine("❌ כמות לא תקינה");
                        continue;
                    }

                    // הוסף מוצר להזמנה דרך BL
                    var sales = s_bl.IOrder.AddProductToOrder(order, productId, quantity);

                    Console.WriteLine($"\n✅ מוצר נוסף בהצלחה!");
                    Console.WriteLine($"   כמות: {quantity}");
                    Console.WriteLine($"   מבצעים זמינים: {sales.Count}");

                    // הדפס סיכום הזמנה עדכני
                    PrintOrderSummary(order);

                    Console.WriteLine("\nרוצה להוסיף עוד מוצרים? (כן = התחל מחדש, לא = 0)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ שגיאה: {ex.Message}");
                    Console.WriteLine("חוזר לתפריט הוספת מוצרים...\n");
                }
            }
        }

        /// <summary>
        /// הדפסת סיכום הזמנה בזמן בנייתה
        /// </summary>
        private static void PrintOrderSummary(Order order)
        {
            Console.WriteLine("\n┌─ סיכום הזמנה עדכני ───────────────────────┐");
            Console.WriteLine($"│ מספר מוצרים בהזמנה: {order.Products.Count}");
            Console.WriteLine("│");

            foreach (var product in order.Products)
            {
                Console.WriteLine($"│ 📦 {product.Name}");
                Console.WriteLine($"│    ID: {product.ProductId} | כמות: {product.Quantity}");
                Console.WriteLine($"│    מחיר בסיס: ${product.BasePrice} | מחיר סופי: ${product.FinalPrice}");
                if (product.Sales?.Count > 0)
                {
                    Console.WriteLine($"│  🎁 מבצעים: {product.Sales.Count}");
                }
                Console.WriteLine("│");
            }

            Console.WriteLine($"│ 💰 סה\"כ הזמנה: ${order.FinalPrice}");
            Console.WriteLine("└─────────────────────────────────────────────┘");
        }

        /// <summary>
        /// ביצוע ההזמנה והדפסת דוח סופי
        /// </summary>
        private static void ExecuteOrder(Order order, BO.Client client)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║     ביצוע ההזמנה║");
                Console.WriteLine("╚════════════════════════════════════════╝\n");

                // שמור מלאיים לפני ביצוע
                var productStocksBefore = new Dictionary<int, int>();
                foreach (var product in order.Products)
                {
                    var dbProduct = s_bl.IProduct.Get(product.ProductId);
                    if (dbProduct != null)
                        productStocksBefore[product.ProductId] = dbProduct.Stock;
                }

                // בצע הזמנה
                s_bl.IOrder.DoOrder(order);

                Console.WriteLine("✅ ההזמנה בוצעה בהצלחה!\n");

                // הדפס דוח סופי מפורט
                PrintFinalReport(order, client, productStocksBefore);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ שגיאה בביצוע הזמנה: {ex.Message}");
            }
        }

        /// <summary>
        /// הדפסת דוח סופי של ההזמנה
        /// </summary>
        private static void PrintFinalReport(Order order, BO.Client client, Dictionary<int, int> stocksBefore)
        {
            Console.WriteLine("┌─ דוח הזמנה סופי ──────────────────────────┐");
            Console.WriteLine($"│ לקוח: {client.Name}");
            Console.WriteLine($"│ ID לקוח: {client.Id}");
            Console.WriteLine("│");
            Console.WriteLine("│ פרטי מוצרים בהזמנה:");
            Console.WriteLine("│");

            int totalSalesUsed = 0;

            foreach (var product in order.Products)
            {
                var dbProduct = s_bl.IProduct.Get(product.ProductId);
                int stockAfter = dbProduct?.Stock ?? 0;
                int stockReduction = stocksBefore.ContainsKey(product.ProductId)
                    ? stocksBefore[product.ProductId] - stockAfter
                    : 0;

                Console.WriteLine($"│ 📦 {product.Name}");
                Console.WriteLine($"│    ID מוצר: {product.ProductId}");
                Console.WriteLine($"│    כמות הורה: {product.Quantity}");
                Console.WriteLine($"│    מחיר בסיס ליחידה: ${product.BasePrice}");
                Console.WriteLine($"│    מחיר סופי: ${product.FinalPrice:F2}");

                if (product.Sales != null && product.Sales.Count > 0)
                {
                    Console.WriteLine($"│    🎁 מבצעים שהשתמשו: {product.Sales.Count}");
                    totalSalesUsed += product.Sales.Count;
                    foreach (var sale in product.Sales)
                    {
                        Console.WriteLine($"│       └─ הנחה {sale.Price * 100:F0}% (קנייה מינימום: {sale.Quantity} יחידות)");
                    }
                }
                else
                {
                    Console.WriteLine($"│    🎁 לא היו מבצעים");
                }

                Console.WriteLine($"│    📉 הוריד מהמלאי: {stockReduction} יחידות");
                Console.WriteLine("│");
            }

            Console.WriteLine($"│ ═════════════════════════════════════════");
            Console.WriteLine($"│ 💰 סה\"כ מחיר סופי: ${order.FinalPrice:F2}");
            Console.WriteLine($"│ 🎁 סה\"כ מבצעים שנוצלו: {totalSalesUsed}");
            Console.WriteLine($"│ ═════════════════════════════════════════");
            Console.WriteLine("└────────────────────────────────────────────┘");

            Console.WriteLine("\n✅ ההזמנה סוגרה בהצלחה!");
            Console.WriteLine("חוזר לתפריט ראשי...");
            Console.WriteLine("\nלחץ Enter כדי להמשיך...");
            Console.ReadLine();
        }

        /// <summary>
        /// תפריט בדיקות מומחה (הקוד המקורי הפשוט יותר)
        /// </summary>
        private static void ShowExpertTestsMenu()
        {
            bool backToMain = false;

            while (!backToMain)
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║      בדיקות מומחה (Advanced Tests)  ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("1. בדיקות הזמנות");
                Console.WriteLine("2. בדיקות מוצרים");
                Console.WriteLine("3. בדיקות לקוחות");
                Console.WriteLine("4. בדיקות מבצעים");
                Console.WriteLine("0. חזור לתפריט ראשי");
                Console.WriteLine("────────────────────────────────────────");
                Console.Write("בחר אפשרות: ");

                string choice = Console.ReadLine() ?? "0";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n📋 בדיקות הזמנות - להשלמה בעתיד");
                        break;
                    case "2":
                        Console.WriteLine("\n📋 בדיקות מוצרים - להשלמה בעתיד");
                        break;
                    case "3":
                        Console.WriteLine("\n📋 בדיקות לקוחות - להשלמה בעתיד");
                        break;
                    case "4":
                        Console.WriteLine("\n📋 בדיקות מבצעים - להשלמה בעתיד");
                        break;
                    case "0":
                        backToMain = true;
                        break;
                    default:
                        Console.WriteLine("❌ בחירה לא תקינה");
                        break;
                }
            }
        }
    }
}
