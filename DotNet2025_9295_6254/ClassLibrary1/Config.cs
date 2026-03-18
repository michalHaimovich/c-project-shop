using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
       
        private  static string fileName = "data-config";
            static XElement dataConfig=XElement.Load(fileName);
         
        private static int productId;

        public static int GetProductId
        {
            get 
            {
                int currentProId = int.Parse(dataConfig.Element("ProductNum").Value); 
                dataConfig.Element("ProductNum").SetValue((currentProId+1).ToString());
                dataConfig.Save(fileName);
                return currentProId;
            }
        }


        private static int saleId;

        public static int GetSaleId
        {
            get
            {
                int currentSaleId = int.Parse(dataConfig.Element("SaleNum").Value);
                dataConfig.Element("SaleNum").SetValue((currentSaleId + 1).ToString());
                dataConfig.Save(fileName);
                return currentSaleId;
            }


        }
    }
}
