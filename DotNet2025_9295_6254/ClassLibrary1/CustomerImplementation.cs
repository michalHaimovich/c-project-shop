
using DalApi;
using DO;
using System.Reflection;
using System.Xml.Serialization;
using Tools;
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
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called create with: " + item);
            if (customersList.Any(c => c.id == item.id)) 
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called create with: " + item +"faild: exists");
                throw new DalAlreadyExistsException($"Customer with ID {item.id} already exists.");
            }
            customersList.Add(item);
            SaveToFile();
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "created successfully");
            return item.id;
        }

        public void Delete(int id)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete with: " + id);
            Customer c = customersList.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                customersList.Remove(c);
                SaveToFile();
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "deleted successfully");
                return;
            }
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete faild : "+id+" does not exists");
            throw new DalDoesNotExistException("couldent delete id: "+id+" does not exists");

        }

        public Customer Read(int id)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read with: " + id);
            Customer c = customersList.FirstOrDefault(x => x.id == id);
            if (c != null)
            {
                return c;
            }
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read faild : " + id + " does not exists");
            throw new DalDoesNotExistException($"Customer with ID {id} does not exist.");
        }

        public Customer Read(Func<Customer, bool> filter)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read by filter ");
            Customer c = ReadAll(filter).FirstOrDefault();
            if (c != null)
            {
                return c;
            }
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read faild :  does not exists");
            throw new DalDoesNotExistException($"Customer with filter does not exist.");
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read all with filter: " + (filter != null ? filter.ToString() : "null"));
            if (filter == null)
                return customersList.ToList();
            return customersList.Where(filter).ToList();
        }

        public void Update(Customer item)
        {
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update with: " + item);
            Customer c = customersList.FirstOrDefault(x => x.id == item.id);
            if (c != null)
            {
                customersList.Remove(c);
                customersList.Add(item);
                SaveToFile();
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "updated successfully");
                return;
            }
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update faild : " + item + " does not exists");
            throw new DalDoesNotExistException($"Customer with ID {item.id} does not exist.");
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
