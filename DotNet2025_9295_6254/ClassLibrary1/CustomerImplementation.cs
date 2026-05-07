using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {
        private static string fileName = "../xml/customers.xml";
        private XmlSerializer customers = new XmlSerializer(typeof(List<Customer>));
        private List<Customer> customersList;

        public CustomerImplementation()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        var loaded = customers.Deserialize(reader) as List<Customer>;
                        customersList = loaded ?? new List<Customer>();
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist, creating new list");
                    customersList = new List<Customer>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customers: {ex.Message}");
                customersList = new List<Customer>();
            }
        }

        public int Create(Customer item)
        {
            customersList.Add(item);
            SaveToFile();
            return item.id;
        }

        public void Delete(int id)
        {
            Customer c = customersList.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                customersList.Remove(c);
                SaveToFile();
            }
        }

        public Customer Read(int id)
        {
            return customersList.FirstOrDefault(x => x.id == id);
        }

        public Customer Read(Func<Customer, bool> filter)
        {
            return ReadAll(filter).FirstOrDefault();
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            if (filter == null)
                return customersList.ToList();
            return customersList.Where(filter).ToList();
        }

        public void Update(Customer item)
        {
            Customer c = customersList.FirstOrDefault(x => x.id == item.id);
            if (c != null)
            {
                customersList.Remove(c);
                customersList.Add(item);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            try
            { 
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    customers.Serialize(writer, customersList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        }
    }
}
