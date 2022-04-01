using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Id
    {
        public List<string> Employee { get; set; }
        public Id(string employeeName)
        {
            this.Employee = new List<string> { employeeName };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Id> companies = new Dictionary<string, Id>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] input2 = input.Split(" -> ");
                string companyName = input2[0];
                string employee = input2[1];
                Id newId = new Id(employee);
                if (companies.ContainsKey(companyName))
                {
                    if (!companies.Any(x => x.Value.Employee.Contains(employee)))
                    {
                        companies[companyName].Employee.Add(employee);
                    }
                }
                else
                {
                    companies.Add(companyName, newId);
                }
                input = Console.ReadLine();
            }
            foreach (var item in companies)
            {
                Console.WriteLine(item.Key);
                foreach(var ids in item.Value.Employee)
                {
                    Console.WriteLine($"-- {ids}");
                }
            }
        }
    }
}
