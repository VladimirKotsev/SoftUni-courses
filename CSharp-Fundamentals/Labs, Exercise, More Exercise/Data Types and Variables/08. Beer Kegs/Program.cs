using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long biggest = -999999999999;
            string name = "";
            for (int i = 1; i <= n; i++)
            {
                string model = Console.ReadLine();
                decimal r = decimal.Parse(Console.ReadLine());
                int h = int.Parse(Console.ReadLine());
                long volume = (long)Math.PI * (long)Math.Pow((double)r, 2) * (long)h;
                if (volume > biggest)
                {
                    biggest = volume;
                    name = model;
                }
            }
            Console.WriteLine(name);
        }
    }
}
