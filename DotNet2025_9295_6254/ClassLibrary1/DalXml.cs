using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    sealed internal class DalXml : IDal
    {
        private DalXml() { }

        private static readonly DalXml instance = new DalXml();

        public static readonly IDal Instance = instance;

        public ISale Sale => new SaleImplementation();

        public IProduct Product => new ProductImplementation();

        public ICustomer Customer => new CustomerImplementation();
    }
    

    }
