using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> coins = new Dictionary<int, int>();

            int[] inputCoins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            foreach(int coin in inputCoins)
            {
                coins.Add(coin, 0);
            }

            int value = int.Parse(Console.ReadLine());

            static Dictionary<int, int> ChooseCoins(Dictionary<int, int> coins, int value)
            {
                if (value == 0)
                {

                }

            }
        }
    }
}
