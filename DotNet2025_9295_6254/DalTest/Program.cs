

using DO;

using DalApi;

using Dal;

using Tools;

namespace DalTest;

internal class Program
{

    private static IDal s_dal =Factory.Get; 

    static void Main(string[] args)
    {
        Initializatation.initialize();
        try
        {
            while (true)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                if (choice == "4") // Exit option
                {
                    break;
                }

                switch (choice)
                {
                    case "0":
                        Tools.LogManager.DeleteOldLogFolders();
                        break;
                    case "1":
                        ShowCrudMenu(s_dal.Sale,"sale");
                        break;
                    case "2":
                        ShowCrudMenu(s_dal.Product,"prduct");
                        break;
                    case "3":
                        ShowCrudMenu(s_dal.Customer,"customer");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    /// <summary>
    /// show the menu of entity
    /// </summary>
        private static void DisplayMainMenu()
    {   Console.WriteLine("wellcome to our electronic store");
        Console.WriteLine("Main Menu:");
        Console.WriteLine("0. Delet old logs");
        Console.WriteLine("1. Sale");
        Console.WriteLine("2. Product");
        Console.WriteLine("3. Customer");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
    }
    /// <summary>
    /// show the menu of crud for each entity
    /// </summary>
    /// <typeparam name="T">the entity</typeparam>
    /// <param name="inter">the interface that implement the crud for the entity</param>
    /// <param name="name">the name of the entity (for visualety)</param>
    private static void ShowCrudMenu<T>(ICrud<T> inter, string name)
    {
       
        Console.WriteLine($"\n CRUD Menu:");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Read all");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("6. Back to Main Menu");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                CreateEntity(inter, name);
                break;
            case "2":
                ReadEntity(inter,name);
                break;
            case "3":
                ReadAllEntity(inter, name);
                break;
            case "4":
               UpdateEntity(inter, name);
                break;
            case "5":
                DeleteEntity(inter, name);
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
    private static void ReadAllEntity<T>(ICrud<T> inter, string name)
    {
        var li = inter.ReadAll();
        Console.WriteLine("the list of "+name+"s :");
        li.ForEach(x => Console.WriteLine(x.ToString()));
    }
    private static void CreateEntity<T>(ICrud<T> inter, string name)
    {

        if (inter is ICrud<Sale>)
        {
            ISale saleInter= (ISale)inter;
            Sale sale = GetSaleFromInput();
            saleInter.Create(sale);
        }
        else if (inter is ICrud<Product>)
        {   
            IProduct productInter = (IProduct)inter;
            var product = GetProductFromInput();
            productInter.Create(product);
        }
        else if (inter is ICrud<Customer>)
        {   
            ICustomer customerInter = (ICustomer)inter;
            var customer = GetCustomerFromInput();
            customerInter.Create(customer);
        }
        else
        {
            Console.WriteLine("Unsupported record type.");
        }
    }

    

    private static Sale GetSaleFromInput()
    {
        Console.WriteLine("Enter Sale details:");
        int id = int.Parse(Console.ReadLine()!);
        int productId = int.Parse(Console.ReadLine()!);
        int amountToSale = int.Parse(Console.ReadLine()!);
        int countToSale = int.Parse(Console.ReadLine()!);
        bool toClub = bool.Parse(Console.ReadLine()!);
        DateTime startDate = DateTime.Parse(Console.ReadLine()!);
        DateTime endDate = DateTime.Parse(Console.ReadLine()!);

        return new Sale(id, productId, amountToSale, countToSale, toClub, startDate, endDate);
    }

    private static Product GetProductFromInput()
    {
        Console.WriteLine("Enter Product details:");
        int id = int.Parse(Console.ReadLine()!);
        ElectricalApplianceCategory category = (ElectricalApplianceCategory)Enum.Parse(typeof(ElectricalApplianceCategory), Console.ReadLine()!);
        string productName = Console.ReadLine()!;
        int price = int.Parse(Console.ReadLine()!);
        int amountInStock = int.Parse(Console.ReadLine()!);

        return new Product(id ,category, productName, price, amountInStock);
    }

    private static Customer GetCustomerFromInput()
    {
        Console.WriteLine("Enter Customer details:");
        int id = int.Parse(Console.ReadLine()!);
        string customerName = Console.ReadLine()!;
        string customerAddress = Console.ReadLine()!;
        string customerPhone = Console.ReadLine()!;

        return new Customer(id, customerName, customerAddress, customerPhone);
    }

    private static void ReadEntity<T>(ICrud<T> inter, string name)
    {
        Console.Write($"Enter ID to read {name}: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine($"Reading {name} with ID: {input}");
        var item =inter.Read(input);
        Console.WriteLine(item.ToString());
    }

    private static void UpdateEntity<T>(ICrud<T> inter, string name)
    {   Console.Write($"Enter ID to update {name}: ");
        int id =int.Parse(Console.ReadLine());

        if (inter is ICrud<Sale>)
        {
            ISale saleInter = (ISale)inter;
            Sale sale = GetSaleFromInput();
            saleInter.Update(sale);
        }
        else if (inter is ICrud<Product>)
        {
            IProduct productInter = (IProduct)inter;
            var product = GetProductFromInput();
            productInter.Update(product);
        }
        else if (inter is ICrud<Customer>)
        {
            ICustomer customerInter = (ICustomer)inter;
            var customer = GetCustomerFromInput();
            customerInter.Update(customer);
        }
        else
        {
            Console.WriteLine("Unsupported record type.");
        }
        Console.WriteLine($"{name} with ID {id} updated");
    }

    private static void DeleteEntity<T>(ICrud<T> inter, string name)
    {
        Console.Write($"Enter ID to delete {name}: ");
        int id = int.Parse(Console.ReadLine());
        inter.Delete(id);
        Console.WriteLine($"{name} with ID {id} deleted.");
    }

    
}
   





  
