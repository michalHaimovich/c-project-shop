using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using DalApi;
using DO;
using Tools;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
    
        private static string fileName = "../xml/sales.xml";
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
             LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read with: " + id);
             XElement sale = sales.Elements(ID).Where(x => x.Value == id.ToString()).FirstOrDefault()!;
            if (sale == null)
            {
                LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read failed: " + id + " does not exists");
                throw new DalDoesNotExistException("sale with id: " +id +" does not exists");
            }
            sale = sale.Parent!;
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
            LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read successfully");
            return s;
        }

 public Sale Read(Func<Sale, bool> filter)
 {
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read by filter");
    Sale result = ReadAll(filter).FirstOrDefault();
    if (result == null)
    {
      LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read failed: does not exists");
      throw new DalDoesNotExistException("couldnt find sale with this filter");
    }
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read by filter successfully");
    return result;
 }

 public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
 {
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called read all with filter: " + (filter != null ? filter.ToString() : "null"));
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
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "read all successfully, found " + list.Count() + " sales");
    return list;
 }

 public int Create(Sale sale)
 {
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called create with: " + sale);
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
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "created successfully");
    return id;
 }

 public void Delete(int id)
 {
    LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete with: " + id);
    if(sales.Elements(SALE).FirstOrDefault(x => x.Element(ID).Value == id.ToString()) == null)
    {
      LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called delete failed: " + id + " does not exists");
      throw new DalDoesNotExistException("sale with id: " + id + " does not exists");
    }
     sales.Elements(SALE).FirstOrDefault(x => x.Element(ID).Value == id.ToString())?.Remove();
     sales.Save(fileName);
     LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "deleted successfully");
    } 

   public void Update(Sale item)
    {
        LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "called update with: " + item);
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
        LogManager.WriteLog(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName, "updated successfully");
    }

 }
}
