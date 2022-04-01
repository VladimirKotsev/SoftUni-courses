using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());
            int k1 = 0;
            int k2 = 0;
            int k3 = 0;
            int k4 = 0;
            for (int i = 1; i <= count; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    k1++;
                    k2++;
                    k3++;
                    if (k3 % 2 == 0)
                    {
                        k4++;
                    }
                }
                else if (i % 2 == 0)
                {
                    k1++;
                }
                else if (i % 3 == 0)
                {
                    k2++;
                }
            }
            Console.WriteLine($"Rage expenses: {priceHeadset * k1 + priceMouse * k2 + priceKeyboard * k3 + priceDisplay * k4:f2} lv.");
        }
    }
}
