using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class BL : BlApi.IBl
    {
        public ISale ISale  => new SaleImplementation();

        public IProduct IProduct => new ProductImplementation();

        public IClient IClient => new ClientImplementation();

        public IOrder Iorder => OrderImplementation();
    }
}
