using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> book = new SortedDictionary<string, int>();
            book.Add("Dipping sauce", 0);
            book.Add("Green salad", 0);
            book.Add("Chocolate cake", 0);
            book.Add("Lobster", 0);
            int counter = 0;

            Queue<int> ingredientValue = FillQueue();
            Stack<int> freshnessLevel = FillStack();

            while (true)
            {
                bool helpVariable = false;
                while (ingredientValue.Peek() == 0)
                {
                    ingredientValue.Dequeue();
                    if (ingredientValue.Count == 0)
                    {
                        helpVariable = true;
                        break;
                    }
                }
                if (helpVariable == true)
                    break;


                int freshness = ingredientValue.Peek() * freshnessLevel.Peek();
                if (freshness == 150) //dipping sauce price
                {
                    counter++;
                    book["Dipping sauce"]++;
                    ingredientValue.Dequeue();
                    freshnessLevel.Pop();
                }
                else if (freshness == 250) // Green salad
                {
                    counter++;
                    book["Green salad"]++;
                    ingredientValue.Dequeue();
                    freshnessLevel.Pop();
                }
                else if (freshness == 300) // Chocolate cake
                {
                    counter++;
                    book["Chocolate cake"]++;
                    ingredientValue.Dequeue();
                    freshnessLevel.Pop();
                }
                else if (freshness == 400) // Lobster
                {
                    counter++;
                    book["Lobster"]++;
                    ingredientValue.Dequeue();
                    freshnessLevel.Pop();
                }
                else
                {
                    freshnessLevel.Pop();
                    ingredientValue.Enqueue(ingredientValue.Peek() + 5);
                    ingredientValue.Dequeue();
                }

                if (ingredientValue.Count == 0 || freshnessLevel.Count == 0)
                {
                    break;
                }

            }//while cycle

            if (counter >= 4) //succeesfully
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredientValue.Count > 0)
            {
                int sum = 0;
                foreach (var ing in ingredientValue)
                    sum += ing;
                Console.WriteLine($"Ingredients left: {sum}");
            }
            var sorted = book.Where(x => x.Value != 0);
            foreach (var dish in sorted)
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
        static Queue<int> FillQueue()
        {
            Queue<int> ingredientValue = new Queue<int>();
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foreach (int n in array)
                ingredientValue.Enqueue(n);

            return ingredientValue;
        }
        static Stack<int> FillStack()
        {
            Stack<int> freshenessLevel = new Stack<int>();
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foreach (int n in array)
                freshenessLevel.Push(n);

            return freshenessLevel;
        }
    }
}
