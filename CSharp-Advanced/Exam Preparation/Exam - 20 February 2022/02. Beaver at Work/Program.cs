using System;
using System.Collections.Generic;


namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            field = FillMatrix(n);
            int row = FindIndexesOfBeaver(field)[0];
            int col = FindIndexesOfBeaver(field)[1];
            int countOfAvalibleBranches = GetCount(field);
            int countBranches = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                string direction = command;
                switch (direction)
                {
                    case "up":
                        if (Validation(field, row, col, direction))
                        {
                            field[row, col] = '-';
                            row--;
                            if (field[row, col] == 'F')
                            {
                                row = field.GetLength(0) - 1;
                                field[row, col] = 'B';
                            }
                            if (field[row - 1, col] > 96 && field[row - 1, col] < 123)
                            {
                                field[row, col] = 'B';
                                countBranches++;
                            }
                        }
                        break;
                    case "down":

                        break;
                    case "left":

                        break;
                    case "right":

                        break;
                }

                command = Console.ReadLine();
            }
        }
        static bool Validation(char[,] field, int row, int col, string direction)
        {
            bool check = true;
            if (direction == "up")
            {
                if (row - 1 < 0)
                {
                    check = false;
                }
            }
            else if (direction == "down")
            {
                if (row + 1 > field.GetLength(0) - 1)
                {
                    check = false;
                }

            }
            else if (direction == "left")
            {
                if (col - 1 < 0)
                {
                    check |= false;
                }
            }
            else if (direction == "right")
            {
                if (col + 1 > field.GetLength(1) - 1)
                {
                    check = false;
                }
            }
            return check;
        }
        static int GetCount(char[,] field)
        {
            int count = 0;
            for (int row = 0; row < field.GetLength(0); row++)
                for (int col = 0; col < field.GetLength(1); col++)
                    if (field[row, col] > 96 && field[row, col] < 123)
                        count++;
            return count;
        }
        static char[,] FillMatrix(int n)
        {
            char[,] field = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = char.Parse(line[col]);
                }
            }
            return field;
        }
        static List<int> FindIndexesOfBeaver(char[,] field)
        {
            List<int> cordinates = new List<int>();
            for (int row = 0; row < field.GetLength(0); row++)
                for (int col = 0; col < field.GetLength(1); col++)
                    if (field[row, col] == 'B')
                    {
                        cordinates.Add(row);
                        cordinates.Add(col);
                    }
            return cordinates;
        }

    }
}
