
using DalApi;
using System.Security.Cryptography.X509Certificates;

namespace BlApi
{
    public interface  IBl
    {
        public ISale ISale { get; }
        
        public IProduct IProduct { get; }
        
        public IClient ICustomer { get; }
        
        public IOrder Iorder { get; }

    }
}
