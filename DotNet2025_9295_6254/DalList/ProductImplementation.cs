using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;

using static Dal.DataSource;



namespace Dal
{
    public class ProductImplementation:IProduct
    {


        public Product Read(int id)
        {

            Product found = products.Find(p => p.id == id);
            if (found == null)
            {
                throw new ExceptionsIdNotFound();
            }

            return found;
        }

        public int Create(Product product)
        {
            int idRun = ProductConfig.Next;
            product = product with { id = idRun };
            products.Add(product);
            return idRun;
        }

        public void Delete(int id)
        {
            int exist = products.FindIndex(c => c.id == id);
            if (exist == -1)
            {
                throw new ExceptionsIdNotFound();
            }
            products.RemoveAt(exist);
        }

        public void Update(Product product)
        {
            Delete(product.id);

            products.Add(product);

        }

        List<Product> ICrud<Product>.ReadAll(Func<Product, bool>? filter)
        {

            List<Product> list = new List<Product>();

            if (filter != null)
            {
                list = products.Where(p => filter(p)).ToList();
            }
            else
            {
                list = products.ToList();

            }


            return list;
        }

        Product ICrud<Product>.Read(Func<Product, bool> filter)
        {
            return products.FirstOrDefault(p => filter(p));

        }

    }

}
