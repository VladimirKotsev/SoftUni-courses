using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            string word = Console.ReadLine();
            Queue<char> snake = new Queue<char>();
            for (int i = 0; i < word.Length; i++)
            {
                snake.Enqueue(word[i]);
            }
            int counter = 0;
            for (int row = 0; row < dimensions[0]; row++)
            {
                if (counter % 2 == 0)
                {
                    for (int col = 0; col < dimensions[1]; col++)
                    {
                        snake.Enqueue(snake.Peek());
                        matrix[row, col] = snake.Dequeue();
                    }
                    counter++;
                }
                else
                {
                    for (int col = dimensions[1] - 1; col >= 0; col--)
                    {
                        snake.Enqueue(snake.Peek());
                        matrix[row, col] = snake.Dequeue();
                    }
                    counter++;
                }
            }
            for (int row = 0; (row < dimensions[0]); row++)
            {
                for (int col = 0; col < dimensions[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
