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
        private string SALE = "sale";
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
            XElement sale = sales.Elements(ID).Where(x => x.Value == id.ToString()).FirstOrDefault().Parent;
            Sale s = new Sale()
            {
                id = int.Parse(sale.Element(ID).Value),
                product_id = int.Parse(sale.Element(PRODUCTID).Value),
                amount_to_sale = int.Parse(sale.Element(AMOUNTTOSALE).Value),
                count_to_sale = int.Parse(sale.Element(COUNTTOSALE).Value),
                to_club = bool.Parse(sale.Element(TOCLUB).Value),
                start_date = DateTime.Parse(sale.Element(STARTDATE).Value),
                end_date = DateTime.Parse(sale.Element(ENDDATE).Value)
            };
            return s;
        }

        public Sale Read(Func<Sale, bool> filter)
        {
            return ReadAll(filter).FirstOrDefault()!;
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
                List<Sale> list = new List<Sale>();
                IEnumerable<XElement> salesList = sales.Elements(SALE);
                
                foreach (var item in salesList)
                {
                    Sale s = new Sale()
                    {
                        id = int.Parse(item.Element(ID).Value),
                        product_id = int.Parse(item.Element(PRODUCTID).Value),
                        amount_to_sale = int.Parse(item.Element(AMOUNTTOSALE).Value),
                        count_to_sale = int.Parse(item.Element(COUNTTOSALE).Value),
                        to_club = bool.Parse(item.Element(TOCLUB).Value),
                        start_date = DateTime.Parse(item.Element(STARTDATE).Value),
                        end_date = DateTime.Parse(item.Element(ENDDATE).Value)
                    };
                    if(filter == null || filter(s))
                        list.Add(s);
                }
                return list;
        }

        public int Create(Sale sale)
        {
            int id = Config.GetSaleId;
            sales.Add(new XElement(SALE,
                new XElement(ID, id),
                new XElement(PRODUCTID, sale.product_id),
                new XElement(AMOUNTTOSALE, sale.amount_to_sale),
                new XElement(COUNTTOSALE, sale.count_to_sale),
                new XElement(TOCLUB, sale.to_club),
                new XElement(STARTDATE, sale.start_date),
                new XElement(ENDDATE, sale.end_date)
            ));
                sales.Save(fileName);
            return id;
        }

        public void Delete(int id)
        {
            sales.Elements(SALE).Where(x => x.Element(ID).Value == id.ToString()).FirstOrDefault()?.Remove();
            sales.Save(fileName);
        } 

        public void Update(Sale item)
        {
            Delete(item.id);
            sales.Add(new XElement(SALE,
                new XElement(ID, item.id),
                new XElement(PRODUCTID, item.product_id),
                new XElement(AMOUNTTOSALE, item.amount_to_sale),
                new XElement(COUNTTOSALE, item.count_to_sale),
                new XElement(TOCLUB, item.to_club),
                new XElement(STARTDATE, item.start_date),
                new XElement(ENDDATE, item.end_date)
            ));
            sales.Save(fileName);
        }

    }
}
