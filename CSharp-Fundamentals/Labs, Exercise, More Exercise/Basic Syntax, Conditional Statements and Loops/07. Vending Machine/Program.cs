using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double coin;
            double money = 0;
            while (input != "Start")
            {
                coin = double.Parse(input);
                if (coin != 0.1 && coin != 0.2 && coin != 0.5 && coin != 1 && coin != 2)
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    money += coin;
                }
                input = Console.ReadLine();
            }
            while (input != "End")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "Nuts":
                        money -= 2.0;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += 2.0;
                        }
                        break;
                    case "Water":
                        money -= 0.7;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += 0.7;
                        }
                        break;
                    case "Crisps":
                        money -= 1.5;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += 1.5;
                        }
                        break;
                    case "Soda":
                        money -= 0.8;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += 0.8;
                        }
                        break;
                    case "Coke":
                        money -= 1.0;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += 1.0;
                        }
                        break;
                    default:
                        {
                            if (input != "End")
                            {
                                Console.WriteLine("Invalid product");
                            }
                            break;
                        }
                }
            }
            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
