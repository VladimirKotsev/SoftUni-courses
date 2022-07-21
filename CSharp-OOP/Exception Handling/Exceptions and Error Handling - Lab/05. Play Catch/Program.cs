namespace _05._Play_Catch
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int countExceptions = 0;

            while (true)
            {
                if (countExceptions == 3)
                    break;

                string[] cmd = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    int index = int.Parse(cmd[1]);
                    if (cmd[0] == "Replace")
                        numbers[index] = int.Parse(cmd[2]);
                    else if (cmd[0] == "Print")
                    {
                        List<int> help = new List<int>();
                        for (int i = index; i <= int.Parse(cmd[2]); i++)
                        {
                            help.Add(numbers[i]);
                        }
                        Console.WriteLine(String.Join(", ", help));
                    }
                    else if (cmd[0] == "Show")
                        Console.WriteLine(numbers[index]);

                }
                catch (FormatException)
                {
                    Console.WriteLine($"The variable is not in the correct format!");
                    countExceptions++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    countExceptions++;
                }

            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
