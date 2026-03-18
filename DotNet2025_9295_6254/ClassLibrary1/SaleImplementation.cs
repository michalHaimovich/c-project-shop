using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
      
        private static string fileName = "sales";
        private string ID = "id";
        private string PRODUCTID = "product_id";
        private string AMOUNTTOSALE = "amount_to_sale";
        private string COUNTTOSALE = "count_to_sale";
        private string TOCLUB = "to_club";
        private string STARTDATE = "start_date";
        private string ENDDATE = "end_date";


        private XElement sales = XElement.Load(fileName);

        public Sale Read(int id)
        {
            
        }

        public Sale Read(Func<Sale, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            return new List<Sale>();
        }

        public int Create(Sale sale)
        {
            return 0;
        }

        public void Delete(int id)
        {

        } 

        public void Update(Sale item)
        {

        }

    }
}
