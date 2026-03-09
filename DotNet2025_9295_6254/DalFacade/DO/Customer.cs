using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Customer(
        int id,
         string customer_name,
         string customer_adress,
         string customer_phon)
    {

        public Customer() : this(0, "", "", "")
        {

        }

        public override string ToString()
        {
            return $"Customer ID: {this.id}, name: {customer_name}, adress: {customer_adress}, phon: {customer_phon}";
        }

    }
}
