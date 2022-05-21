using System;
using System.Linq;

namespace _06._Jagged_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                    matrix[i] = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmd = command.Split(' ');
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                switch (cmd[0])
                {
                    case "Add":
                        if (row >= 0 && row < rows
                            && 
                            col >= 0 && col <= matrix.GetLength(0))
                            matrix[row][col] += value;
                        else
                            Console.WriteLine("Invalid coordinates");
                        break;
                    case "Subtract":
                        if (row >= 0 && row < rows
                           &&
                           col >= 0 && col <= matrix.GetLength(0))
                            matrix[row][col] -= value;
                        else
                            Console.WriteLine("Invalid coordinates");
                        break;
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(String.Join(' ', matrix[i]));
            }
        }
    }
}
