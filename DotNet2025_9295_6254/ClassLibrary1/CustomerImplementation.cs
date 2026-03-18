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
       private static string fileName = "customers";
        private XmlSerializer customers = new XmlSerializer(typeof(List<Customer>));
        private List<Customer> customersList = (new XmlSerializer(typeof(List<Customer>))).Deserialize(new StreamReader(fileName)) as List<Customer>;

        public int Create(Customer item)
        {
            using(StreamWriter writer = new StreamWriter(fileName))
            {
                
                customersList.Add(item);
                customers.Serialize(writer, customersList);
            }
            return item.id;
        }

        public void Delete(int id)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                
                Customer c = customersList.Where(x => x.id == id).FirstOrDefault();
                if(c != null)
                    customersList.Remove(c);
                customers.Serialize(writer, customersList);
            }
        }

        public Customer Read(int id)
        {
            return customersList.Where(x => x.id == id).FirstOrDefault();
        }

        public Customer Read(Func<Customer, bool> filter)
        {
            return ReadAll(filter).FirstOrDefault();
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter)
        {
                if (filter == null)
                    return customersList;
                return customersList.Where(filter).ToList();
        }

        public void Update(Customer item)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Customer c = customersList.Where(x => x.id == item.id).FirstOrDefault();
                if (c != null)
                {
                    customersList.Remove(c);
                    customersList.Add(item);
                }
                customers.Serialize(writer, customersList);
            }
        }
    }
}
