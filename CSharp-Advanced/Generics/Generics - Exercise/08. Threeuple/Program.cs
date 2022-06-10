using System;
using System.Text;
using System.Linq;

namespace _08._Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = $"{input1[0]} {input1[1]}";
            string adress = input1[2];
            for (int i = 3; i < input1.Length; i++)
                sb.Append(input1[i]);
            string city = sb.ToString();
            Threeuple<string, string, string> first = new Threeuple<string, string, string>(name, adress, city);
            Console.WriteLine(first);

            var input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name2 = input2[0];
            int litter = int.Parse(input2[1]);
            bool isDrunk = input2[2] == "drunk";
            Threeuple<string, int, bool> second = new Threeuple<string, int, bool>(name2, litter, isDrunk);
            Console.WriteLine(second);

            var input3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name3 = input3[0];
            double accBalance = double.Parse(input3[1]);
            string bankName = input3[2];
            Threeuple<string, double, string> third = new Threeuple<string, double, string>(name3, accBalance, bankName);
            Console.WriteLine(third);

        }
    }
}
