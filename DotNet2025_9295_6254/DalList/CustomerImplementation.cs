

using DO;
using DalApi;

using static Dal.DataSource;

namespace Dal;


public class CustomerImplementation : ICustomer
{

    public Customer Read(int id)
    {


        var q = from c in customers
                where c.id == id
                select c;

        if (q.FirstOrDefault() == null)
            throw new ExceptionsIdNotFound();
        else
            return q.FirstOrDefault();
   
    }

    public int Create(Customer customer)
    {

       // צריך לעשות רק ב customer
        bool exist = sales.Any(c => c.id == customer.id);
        if (exist)
        {
            throw new ExceptionIDAllredyExist();
        }
        customers.Add(customer);
        return customer.id;


    }

    public void Delete(int id)
    {
        //int exist = customers.FindIndex(c => c.id == id);
        //if (exist == -1)
        //{
        //    throw new ExceptionsIdNotFound();
        //}
        //customers.RemoveAt(exist);
        var q = from c in customers
                where c.id == id
                select c;
 //var s1 = q.FirstOrDefault();
        Customer? s1 = q.FirstOrDefault();
       
        if (s1 == null)
            throw new ExceptionsIdNotFound();
        customers.Remove(s1);

    }

    public void Update(Customer customer)
    {
        Delete(customer.id);

        customers.Add(customer);

    }

    List<Customer> ICrud<Customer>.ReadAll(Func<Customer, bool>? filter)
    {   

        List<Customer> list = new List<Customer>();
                
        if(filter != null) {
            list = customers.Where(c => filter(c)).ToList();  //
        }
        else
        {
            list = customers.ToList();//
   
        }


        return list;
    }

    Customer ICrud<Customer>.Read(Func<Customer, bool> filter)
    {
        return customers.FirstOrDefault(c => filter(c));
    }
}
