using System;

namespace _07._Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = $"{input1[0]} {input1[1]}";
            string adress = input1[2];
            Tuple<string, string> first = new Tuple<string, string>(name, adress);
            Console.WriteLine(first);

            var input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name2 = input2[0];
            int litterBeer = int.Parse(input2[1]);
            Tuple<string, int> second = new Tuple<string, int>(name2, litterBeer);
            Console.WriteLine(second);
            
            var input3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int integer = int.Parse(input3[0]);
            double d = double.Parse(input3[1]);
            Tuple<int, double> third = new Tuple<int, double>(integer, d);
            Console.WriteLine(third);
        }
    }
}
