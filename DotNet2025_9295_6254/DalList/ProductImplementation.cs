using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;
using System.Reflection;
using Tools;
using static Dal.DataSource;



namespace Dal;

public class ProductImplementation : IProduct
{


    public Product Read(int id)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read by id with: " + id);
        var q = from p in products
                where p.id == id
                select p;

        if (q.FirstOrDefault() == null)
        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, " id accepted not exist");
            throw new ExceptionsIdNotFound();
        }
        else
        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, " end read call found product");
            return q.FirstOrDefault();
        }
    }

    public int Create(Product product)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, " called create with " + product);
        int idRun = ProductConfig.Next;
        product = product with { id = idRun };
        products.Add(product);
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "created seccsesfully");
        return idRun;
    }

    public void Delete(int id)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete with id : " + id);

        var q = from p in products
                where p.id == id
                select p;

        Product? p1 = q.FirstOrDefault();
        if (p1 == null)
        {
            Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "exception no id was found to delete");
            throw new ExceptionsIdNotFound();
        }

        products.Remove(p1);
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "deleted seccesfully");
    }

    public void Update(Product product)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update ");
        Delete(product.id);

        products.Add(product);

    }

    List<Product> ICrud<Product>.ReadAll(Func<Product, bool>? filter)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read all with filter: " + filter);

        List<Product> list = new List<Product>();

        if (filter != null)
        {
            list = products.Where(p => filter(p)).ToList();
        }
        else
        {
            list = products.ToList();

        }

        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "end read all call found " + list.Count() + " products");
        return list;
    }

    Product ICrud<Product>.Read(Func<Product, bool> filter)
    {
        Tools.LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read with filter: " + filter);
        return products.FirstOrDefault(p => filter(p));

    }

}
