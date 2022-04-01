using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class DueShift
    {
        public string Name { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public DueShift(string name, string product, int count, decimal price)
        {
            this.Name = name;
            this.Product = product;
            this.Count = count;
            this.Price = price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"%(?<customer>[A-Z][a-z]+)%|\<(?<product>[A-Z][a-z]+)\>|\|(?<count>\d+)\||(?<price>\d+\d+|\d+.\d+)\$";
            string input = Console.ReadLine();
            List<DueShift> shift = new List<DueShift>();
            decimal total = 0;
            while (input != "end of shift")
            {
                MatchCollection match = Regex.Matches(input, regex);
                if (match.Count == 4)
                {
                    string customer = match[0].Groups["customer"].Value;
                    string product = match[1].Groups["product"].Value;
                    int count = int.Parse(match[2].Groups["count"].Value);
                    decimal price = decimal.Parse(match[3].Groups["price"].Value);
                    //DueShift newsold = new DueShift(customer, product, count, price);
                    Console.WriteLine($"{customer}: {product} - {price * (decimal)count:f2}");
                    total += price * (decimal)count;
                }

                input = Console.ReadLine();
            } //end while

            //decimal total = 0;
            //foreach (var customer in shift)
            //{
            //    Console.WriteLine($"{customer.Name}: {customer.Product} - {customer.Price * (decimal)customer.Count:f2}");
            //    total += (decimal)customer.Count * customer.Price;
            //}
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
