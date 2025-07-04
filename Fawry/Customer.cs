using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Customer(string Name, double Balance)
        {
            this.Name = Name;
            this.Balance = Balance;
        }
    }
}
