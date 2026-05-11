using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dal
{
    /// <summary>
    /// //////////////////////////////////////////////////////////////
    /// </summary>
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
                Console.WriteLine($"Error loading customers: {ex.Message}");
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
            int id = Config.GetProductId;
            productsList.Add(item with { id = id});
            SaveToFile();
            return id;
        }

        public void Delete(int id)
        { 
            Product item = productsList.Find(x => x.id == id);
            if (item == null)
            {
                throw new DalDoesNotExistException("cannot delete product with id: "+id+ ", does not exists");
            }
            productsList.Remove(item);
            SaveToFile();
        }

        public Product Read(int id)
        {
            Product item = productsList.Find(x=> x.id == id);
            if(item == null)
            {
                throw new DalDoesNotExistException("product with id: " + id + " does not exists");
            }
            return item;
        }

        public Product Read(Func<Product, bool> filter)
        {
            Product item = productsList.Find(x => filter(x));
            return item;
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            if(filter == null)
                return productsList;
            return productsList.Where(x => filter(x)).ToList();
        }


        public void Update(Product item)
        {
            Product toUpdate = productsList.Find(x => x.id == item.id);
            if (toUpdate == null)
            {
                throw new DalDoesNotExistException("cannot update product with id: " + item.id + " does not exist");
            }
            productsList.Remove(toUpdate);
            productsList.Add(item);
            SaveToFile();
        }
    }
    /////////////////////////////////////////////////////////
}
