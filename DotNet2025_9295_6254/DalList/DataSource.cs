using DO;

namespace Dal
{
    static internal class DataSource
    {
       static internal List<Sale> sales = new List<Sale>();

        static internal List<Customer> customers = new List<Customer>();

        static internal List<Product> products = new List<Product>();


    }

    static internal class ProductConfig
    {
        internal const int start = 1001; // product ids can start from a different base

        private static int current = start;

        public static int Next
        {
            get { return current++; }
        }
    }

    static internal class SaleConfig
    {
        internal const int start = 100; // sale ids start from 100

        private static int current = start;

        public static int Next
        {
            get { return current++; }
        }
    }
}


