using System;
using System.Linq;

namespace _04._MatrixShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            for (int row = 0; row < dimensions[0]; row++)
            {
                string[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                bool checkRow1 = false;
                bool checkRow2 = false;
                bool checkCol1 = false;
                bool checkCol2 = false;

                int row1 = int.Parse(cmd[1]);
                int row2 = int.Parse(cmd[3]);
                int col1 = int.Parse(cmd[2]);
                int col2 = int.Parse(cmd[4]);
                if (cmd[0] == "swap" && cmd.Length == 5)
                {
                    checkRow1 = row1 >= 0 && row1 <= dimensions[0];
                    checkRow2 = row2 >= 0 && row2 <= dimensions[0];
                    checkCol1 = col1 >= 0 && col1 <= dimensions[1];
                    checkCol2 = col2 >= 0 && col2 <= dimensions[1];
                    if (checkRow1 && checkRow2 && checkCol1 && checkCol2)
                    {
                        string help = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = help;
                        for (int row = 0; row < dimensions[0]; row++)
                        {
                            for (int col = 0; col < dimensions[1]; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }
        }
    }
}
