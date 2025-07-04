using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Shipable { get; set; }
        public double? Weight { get; set; }
        public bool Expireable { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Product(string Name,
            double Price,
            int Quantity,
            bool Shipable = false,
            double? Weight = null,
            bool Expireable = false,
            DateTime? ExpiryDate = null)
        {
            this.Name = Name;
            this.Price = Price;
            this.Shipable = Shipable;
            this.Weight = Weight;
            this.Expireable = Expireable;
            this.ExpiryDate = ExpiryDate;
            this.Quantity = Quantity;
        }
    }
}
