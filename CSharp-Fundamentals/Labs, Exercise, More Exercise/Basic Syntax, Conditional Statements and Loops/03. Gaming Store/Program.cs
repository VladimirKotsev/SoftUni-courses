using System;

namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double money = balance;
            string input = Console.ReadLine();
            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4": balance -= 39.99; 
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Bought OutFall 4");
                        }
                        break;
                    case "CS: OG": balance -= 15.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 15.99;
                        }
                        else
                        {
                            Console.WriteLine("Bought CS: OG");
                        }
                        break;
                    case "Zplinter Zell": balance -= 19.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 19.99;
                        }
                        else
                        {
                            Console.WriteLine("Bought Zplinter Zell");
                        }
                        break;
                    case "Honored 2": balance -= 59.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 59.99;
                        }
                        else
                        {
                            Console.WriteLine("Bought Honored 2");
                        }
                        break;
                    case "RoverWatch": balance -= 29.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 29.99;
                        }
                        else
                        {
                            Console.WriteLine("Bought RoverWatch");
                        }
                        break;
                    case "RoverWatch Origins Edition": balance -= 39.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Bought RoverWatch Origins Edition");
                        }
                        break;
                    default: Console.WriteLine("Not Found"); break;
                }
                input = Console.ReadLine();
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }   
            }
            double moneySpended = money - balance;
            double moneyLeft = balance;
            Console.WriteLine($"Total spent: ${moneySpended:f2}. Remaining: ${moneyLeft:f2}");
        }
    }
}
