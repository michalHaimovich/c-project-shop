using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class BL : BlApi.IBl
    {
        public BlApi.ISale ISale  => new SaleImplementation();

        public BlApi.IProduct IProduct => new ProductImplementation();

        public BlApi.IClient IClient => new ClientImplementation();

        public BlApi.IOrder IOrder => new OrderImplementation();

    }
}
