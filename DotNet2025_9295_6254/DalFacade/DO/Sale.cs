using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Sale( 
        int id,
         int product_id,
         int amount_to_sale,
         int count_to_sale,
         bool to_club,
         DateTime start_date,
         DateTime end_date)
    {
        

        public Sale():this(0,0,0,0,false,DateTime.Now,DateTime.Today)
        {
        }

        public override string ToString()
        {
            return $"Sale ID: {this.id}, Product ID: {this.product_id},\n Amount to Sale: {this.amount_to_sale}, " +
                   $"Count to Sale: {count_to_sale}, To Club: {to_club}, " +
                   $"\n Start Date: {start_date}, End Date: {end_date}";
        }
        
    }
}
