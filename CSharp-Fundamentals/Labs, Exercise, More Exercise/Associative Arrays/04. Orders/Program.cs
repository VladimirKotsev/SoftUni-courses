using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Orders
{
    class ForProduct
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ForProduct(decimal price, int count)
        {
            this.Price = price;
            this.Quantity = count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ForProduct> shoppingList = new Dictionary<string, ForProduct>();
            string input = Console.ReadLine();
            while(input != "buy")
            {
                string[] order = input.Split(' ');
                string product = order[0];
                decimal price = decimal.Parse(order[1]);
                int quantity = int.Parse(order[2]);
                ForProduct newProduct = new ForProduct(price, quantity);
                if (shoppingList.ContainsKey(product))
                {
                    shoppingList[product].Price = price;
                    shoppingList[product].Quantity += quantity;
                }
                else
                {
                    shoppingList.Add(product, newProduct);
                }
                input = Console.ReadLine();
            }
            foreach (var c in shoppingList)
            {
                Console.WriteLine($"{c.Key} -> {(decimal)c.Value.Quantity * c.Value.Price:f2}");
            }
        }
    }
}
