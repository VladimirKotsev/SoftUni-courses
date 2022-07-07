
namespace _03._Shopping_Spree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] inputPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var person in inputPeople)
            {
                try
                {
                    string[] helper = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    people.Add(new Person(helper[0], int.Parse(helper[1])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            List<Product> products = new List<Product>();
            string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var product in inputProducts)
            {
                try
                {
                    string[] helper = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    products.Add(new Product(helper[0], int.Parse(helper[1])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {

                while (input[0] != "END")
                {                
                    int indexPerson = people.FindIndex(x => x.Name == input[0]);
                    int indexProduct = products.FindIndex(x => x.Name == input[1]);

                    if (people[indexPerson].Money >= products[indexProduct].Cost)
                    {
                        people[indexPerson].AddProductToBag(products[indexProduct]);
                        people[indexPerson].ReduceMoney(products[indexProduct].Cost);
                        Console.WriteLine($"{input[0]} bought {input[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} can't afford {input[1]}");
                    }

                    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }
    }
}
