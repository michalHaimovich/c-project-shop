using DO;

using DalApi;
using System;
using Tools;

namespace DalTest
{
    public static class Initializatation
    {
        private static IDal s_dal;       
        private static List<int> s_productIds = new List<int>();

        private static void createSales(ISale sale)
        {
            sale.Create(new Sale(1, s_productIds[0], 50, 5, true, DateTime.Now, DateTime.Now.AddDays(10)));
            sale.Create(new Sale(2, s_productIds[1], 30, 3, false, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(5)));
            sale.Create(new Sale(3, s_productIds[2], 20, 1, true, DateTime.Now.AddDays(2), DateTime.Now.AddDays(12)));
            sale.Create(new Sale(4, s_productIds[3], 100, 10, false, DateTime.Now, DateTime.Now.AddDays(15)));
            sale.Create(new Sale(5, s_productIds[4], 15, 2, true, DateTime.Now.AddDays(1), DateTime.Now.AddDays(3)));

        }
        private static void createProduct(IProduct Product)
        {

            s_productIds.Add(Product.Create(new Product(1001, ElectricalApplianceCategory.ENTERTAINMENT, "Laptop", 1500, 20)));
            s_productIds.Add(Product.Create(new Product(1002, ElectricalApplianceCategory.PERSONAL_CARE, "phone", 700, 50)));
            s_productIds.Add(Product.Create(new Product(1003, ElectricalApplianceCategory.ENTERTAINMENT, "Headphones", 150, 100)));
            s_productIds.Add(Product.Create(new Product(1004, ElectricalApplianceCategory.PERSONAL_CARE, "Smartwatch", 300, 30)));
            s_productIds.Add(Product.Create(new Product(1005, ElectricalApplianceCategory.ENTERTAINMENT, "Tablet", 400, 40)));
            s_productIds.Add(Product.Create(new Product(1006, ElectricalApplianceCategory.PERSONAL_CARE, "Monitor", 250, 15)));
            s_productIds.Add(Product.Create(new Product(1007, ElectricalApplianceCategory.PERSONAL_CARE, "Keyboard", 75, 80)));
            s_productIds.Add(Product.Create(new Product(1008, ElectricalApplianceCategory.PERSONAL_CARE, "Mouse", 25, 200)));
            s_productIds.Add(Product.Create(new Product(1009, ElectricalApplianceCategory.PERSONAL_CARE, "Printer", 200, 10)));
            s_productIds.Add(Product.Create(new Product(1010, ElectricalApplianceCategory.CLEANING, "External Hard Drive", 120, 25)));


        }
        private static void createCustomers(ICustomer Customer)
        {

            Customer.Create(new Customer(6254, "Michal", "Modiin Ilit", "0556781551"));
            Customer.Create(new Customer(1023, "David", "Tel Aviv", "0541234567"));
            Customer.Create(new Customer(4872, "Sarah", "Jerusalem", "0539876543"));
            Customer.Create(new Customer(3456, "Yossi", "Haifa", "0523456789"));
            Customer.Create(new Customer(7890, "Tamar", "Beersheba", "0512345678"));
            Customer.Create(new Customer(2345, "Omer", "Eilat", "0587654321"));
            Customer.Create(new Customer(5678, "Noa", "Raanana", "0578901234"));
            Customer.Create(new Customer(1357, "Gilad", "Petah Tikva", "0501234567"));
            Customer.Create(new Customer(2468, "Amit", "Kfar Saba", "0598765432"));
            Customer.Create(new Customer(3690, "Liraz", "Ashdod", "0567890123"));
        }
        public static void initialize(IDal dal)
        {
            s_dal = dal;

            createProduct(dal.Product);
            createSales(dal.Sale);
            createCustomers(dal.Customer);

        }
    }
}
