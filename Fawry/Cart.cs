using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry
{
    public class Cart
    {
        public List<Item> items = new List<Item>();
        public void add(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("Insufficient Quantity, please enter sufficient quantity");
            }
            if (quantity > product.Quantity)
            {
                throw new Exception($"not enough stock for {product.Name}");
            }
            if (product.Expireable && DateTime.Now > product.ExpiryDate)
            {
                throw new Exception("This product is expired!");
            }
            product.Quantity -= quantity;
            items.Add(new Item(product, quantity));

        }
        public bool IsEmpty => items.Count == 0;
        public double SubTotal()
        {
            if (IsEmpty)
            {
                throw new Exception("Cart is empty!");
            }
            double subTotal = 0;
            for (int i = 0; i < items.Count; i++)
            {
                Product prod = items[i].product;
                subTotal += prod.Price * items[i].Quantity;
            }
            return subTotal;
        }
        public (double totalShiping, double? totalWeight) TotalShipping()
        {
            if (IsEmpty)
            {
                throw new Exception("Cart is empty!");
            }
            double totalShiping = 0;
            double? totalWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                Product prod = items[i].product;
                if (prod.Shipable)
                {
                    totalShiping += (10 * items[i].Quantity);
                    totalWeight += (prod.Weight ?? 0) * items[i].Quantity;
                }
            }
            return (totalShiping, totalWeight);
        }
        public void ReturnItemsToStock()
        {
            foreach (var item in items)
            {
                item.product.Quantity += item.Quantity;
            }
        }
    }
}
