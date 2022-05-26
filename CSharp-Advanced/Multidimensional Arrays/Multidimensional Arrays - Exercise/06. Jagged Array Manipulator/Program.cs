using System;
using System.Linq;

namespace _06._Jagged_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] *= 2;
                        matrix[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < matrix[row].Length; i++)
                    {
                        matrix[row][i] /= 2;
                    }
                    for (int i = 0; i < matrix[row + 1].Length; i++)
                    {
                        matrix[row + 1][i] /= 2;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmd = command.Split(' ');
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                switch (cmd[0])
                {
                    case "Add":
                        if (row >= 0 && row < n && col >= 0 && col < matrix[row].Length)
                            matrix[row][col] += value;
                        break;
                    case "Subtract":
                        if (row >= 0 && row < n && col >= 0 && col < matrix[row].Length)
                            matrix[row][col] -= value;
                        break;
                }
                command = Console.ReadLine();
            }
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(String.Join(' ', matrix[row]));
            }
        }
    }
}

