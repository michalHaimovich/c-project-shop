using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tools;
using System.Reflection;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {

        private static string fileName = "../xml/products.xml";
        private XmlSerializer customers = new XmlSerializer(typeof(List<Product>));
        private List<Product> productsList;

        public ProductImplementation()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        var loaded = customers.Deserialize(reader) as List<Product>;
                        productsList = loaded ?? new List<Product>();
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist, creating new list");
                    productsList = new List<Product>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products: {ex.Message}");
                productsList = new List<Product>();
            }
        }

        private void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    customers.Serialize(writer, productsList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        }

        public int Create(Product item)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called create with: " + item);
            if (productsList.Any(p => p.id == item.id))
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called create with: " + item + " failed: already exists");
                throw new DalAlreadyExistsException($"Product with ID {item.id} already exists.");
            }
            int id = Config.GetProductId;
            productsList.Add(item with { id = id });
            SaveToFile();
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "created successfully");
            return id;
        }

        public void Delete(int id)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete with: " + id);
            Product item = productsList.Find(x => x.id == id);
            if (item == null)
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete failed: " + id + " does not exists");
                throw new DalDoesNotExistException("cannot delete product with id: " + id + ", does not exists");
            }
            productsList.Remove(item);
            SaveToFile();
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "deleted successfully");
        }

        public Product Read(int id)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read with: " + id);
            Product item = productsList.Find(x => x.id == id);
            if (item == null)
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read failed: " + id + " does not exists");
                throw new DalDoesNotExistException("product with id: " + id + " does not exists");
            }
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read successfully");
            return item;
        }

        public Product Read(Func<Product, bool> filter)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read by filter");
            Product item = productsList.FirstOrDefault(x => filter(x));
            if (item == null)
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read failed: product with filter does not exists");
                throw new DalDoesNotExistException("product with filter: " + filter.ToString() + " does not exists");
            }
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read by filter successfully");
            return item;
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read all with filter: " + (filter != null ? filter.ToString() : "null"));
            if (filter == null)
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read all successfully, found " + productsList.Count + " products");
                return productsList;
            }
            List<Product> result = productsList.Where(x => filter(x)).ToList();
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read all successfully, found " + result.Count + " products");
            return result;
        }

        public void Update(Product item)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update with: " + item);
            Product toUpdate = productsList.Find(x => x.id == item.id);
            if (toUpdate == null)
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update failed: " + item + " does not exists");
                throw new DalDoesNotExistException("cannot update product with id: " + item.id + " does not exist");
            }
            productsList.Remove(toUpdate);
            productsList.Add(item);
            SaveToFile();
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "updated successfully");
        }
    }
}
