using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(
         int id,
         ElectricalApplianceCategory category,
         string product_name,
         int price,
         int amount_in_stock)
    {

        public Product():this(0,ElectricalApplianceCategory.KITCHEN,"",0,0)
        {
        }

        public override string ToString()
        {
            return $"Product ID: {this.id},category: {category}, name: {product_name}, price: {price}, amount in stock: {amount_in_stock}";
        }
    }
}
