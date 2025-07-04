using Fawry;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void CheckOut(Customer customer, Cart cart) 
    {
        if (cart.IsEmpty)
        {
            throw new Exception("Cart is empty!");
        }
        List<Item> items = new List<Item>();
        double subTotal = cart.SubTotal();
        (double totalShiping, double? totalWeight) = cart.TotalShipping();
        double totalAmount = subTotal + totalShiping;
        if (totalAmount > customer.Balance)
        {
            cart.ReturnItemsToStock();
            throw new Exception("not enough balance, products have been returned to stock.");
        }
        customer.Balance -= totalAmount;
        if (totalShiping > 0) {
            Console.WriteLine("** Shipment notice **");
            foreach (var item in cart.items) {
                if (item.product.Shipable) { 
                    double weight = item.product.Weight ?? 0;
                    Console.WriteLine($"{item.Quantity}x {item.product.Name}\t\t{weight*item.Quantity}g");
                }
            }
            Console.WriteLine($"Total package weight\t{(totalWeight ?? 0) / 1000}kg");
            Console.WriteLine("");
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.items)
            {
                    Console.WriteLine($"{item.Quantity}x {item.product.Name}\t\t{item.product.Price * item.Quantity}$");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal\t\t{subTotal}");
            Console.WriteLine($"Shipping\t\t{totalShiping}");
            Console.WriteLine($"Amount\t\t{totalAmount}");
        }
    }
    public static void Main()
    {
        //Working test
        var cheese = new Product("Cheese", 100, 10, true, 200, true, DateTime.Now.AddDays(2));
        var card = new Product("Scratch Card", 50, 20);
        var tv = new Product("TV", 3000, 5, true, 5000);

        var customer = new Customer("Ali", 5000);

        var cart = new Cart();
        cart.add(cheese, 2);
        cart.add(cheese, 8);
        cart.add(card, 1);
        try
        {
            CheckOut(customer, cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        //////////////////////////////////////////////////////////////////////

        //Test for insufficient balance
        var cheese2 = new Product("Cheese", 100, 10, true, 200, true, DateTime.Now.AddDays(2));
        var card2 = new Product("Scratch Card", 50, 20);
        var tv2 = new Product("TV", 3000, 5, true, 5000);

        var customer2 = new Customer("Ahmed", 900);

        var cart2 = new Cart();
        cart2.add(cheese2, 2);
        cart2.add(cheese2, 8);
        cart2.add(card2, 1);
        try
        {
            CheckOut(customer2, cart2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        //////////////////////////////////////////////////////////////////////

        //Test for expiry date
        var cheese3 = new Product("Cheese", 100, 10, true, 200, true, DateTime.Now.AddDays(-2));
        var card3 = new Product("Scratch Card", 50, 20);
        var tv3 = new Product("TV", 3000, 5, true, 5000);

        var customer3 = new Customer("Ali", 900);

        var cart3 = new Cart();
        cart3.add(cheese3, 2);
        cart3.add(cheese3, 8);
        cart3.add(card3, 1);
        try
        {
            CheckOut(customer3, cart3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
