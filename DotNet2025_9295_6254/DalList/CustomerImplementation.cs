using DO;
using DalApi;
using System.Reflection;
using Tools;
using static Dal.DataSource;

namespace Dal;


public class CustomerImplementation : ICustomer
{

    public Customer Read(int id)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read by id with: " + id);

        var q = from c in customers
                where c.id == id
                select c;

        if (q.FirstOrDefault() == null)
        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, " id accepted not exist");
            throw new ExceptionsIdNotFound();
        }
        else

        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, " end read call found customer");
            return q.FirstOrDefault();
        }

    }

    public int Create(Customer customer)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, " called create with " + customer);

        // צריך לעשות רק ב customer
        bool exist = sales.Any(c => c.id == customer.id);
        if (exist)
        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "exception id already exists");
            throw new ExceptionIDAllredyExist();
        }
        customers.Add(customer);
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "created successfully");
        return customer.id;


    }

    public void Delete(int id)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete with id : " + id);

        var q = from c in customers
                where c.id == id
                select c;


        Customer? s1 = q.FirstOrDefault();

        if (s1 == null)
        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "exception no id was found to delete");
            throw new ExceptionsIdNotFound();
        }
        customers.Remove(s1);
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "deleted successfully");

    }

    public void Update(Customer customer)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update ");
        Delete(customer.id);

        customers.Add(customer);

    }

    List<Customer> ICrud<Customer>.ReadAll(Func<Customer, bool>? filter)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read all with filter");

        List<Customer> list = new List<Customer>();

        if (filter != null)
        {
            list = customers.Where(c => filter(c)).ToList();
        }
        else
        {
            list = customers.ToList();

        }

        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all call found " + list.Count() + " customers");
        return list;
    }

    Customer ICrud<Customer>.Read(Func<Customer, bool> filter)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read with filter");
        return customers.FirstOrDefault(c => filter(c));
    }
}
