using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry
{
    public class Item
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        public Item(Product product, int Quantity)
        {
            this.product = product;
            this.Quantity = Quantity;
        }
    }
}
