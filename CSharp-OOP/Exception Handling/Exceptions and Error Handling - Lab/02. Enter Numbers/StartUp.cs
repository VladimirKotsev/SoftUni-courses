namespace _02._Enter_Numbers
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int start = 1;
            int end = 100;

            while (true)
            {
                try
                {
                    if (numbers.Count == 10)
                    { break; }

                    int n = int.Parse(Console.ReadLine());
                    start = ReadNumbers(start, end, n);

                    numbers.Add(start);
                 
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Number!");
                }

            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        static int ReadNumbers(int start, int end, int number)
        {
            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
            else
            {
                start = number;
            }

            return start;
        }
    }
}
