using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> locations = new Dictionary<string, int>();
            locations.Add("Sink", 0);
            locations.Add("Oven", 0);
            locations.Add("Countertop", 0);
            locations.Add("Wall", 0);
            locations.Add("Floor", 0);

            Stack<int> whiteTiles = FillStack(); 
            Queue<int> greyTiles = FillQueue();



            while (true)
            {
                int largerTile = 0;
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    largerTile = whiteTiles.Pop() + greyTiles.Dequeue();
                    if (largerTile == 40) //sink
                        locations["Sink"]++;
                    else if (largerTile == 50) //Oven
                        locations["Oven"]++;
                    else if (largerTile == 60) // Countertop
                        locations["Countertop"]++;
                    else if (largerTile == 70) // Wall
                        locations["Wall"]++;
                    else // for floor
                        locations["Floor"]++;
                }
                else // don't match
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }


                if (whiteTiles.Count == 0 || greyTiles.Count == 0)
                    break;
            }

            PrintTilesLeft(whiteTiles, greyTiles);   
            foreach (var loc in locations
                .Where(t => t.Value > 0)
                .OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key))
            {
                Console.WriteLine($"{loc.Key}: {loc.Value}");
            }

        }
        static Queue<int> FillQueue() // grey tiles
        {
            var queue = new Queue<int>();
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int num in array)
                queue.Enqueue(num);

            return queue;
        }
        static Stack<int> FillStack() // white tiles
        {
            Stack<int> stack = new Stack<int>();
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach(int num in array)
                stack.Push(num);

            return stack;
        }
        static void PrintTilesLeft(Stack<int> whiteTiles, Queue<int> greyTiles)
        {
            if (whiteTiles.Count > 0)
                Console.WriteLine($"White tiles left: {String.Join(", ", whiteTiles)}");
            else if (whiteTiles.Count == 0)
                Console.WriteLine("White tiles left: none");
            if (greyTiles.Count > 0)
                Console.WriteLine($"Grey tiles left: {String.Join(", ", greyTiles)}");
            else if (greyTiles.Count == 0)
                Console.WriteLine("Grey tiles left: none");
        }
    }
}
