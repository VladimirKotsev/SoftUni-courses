using System;
using System.Linq;

namespace _02._Warships
{
    public class Program
    {
        static void Main(string[] args)
        {
            //input
            int size = int.Parse(Console.ReadLine());
            string[] attacks = Console.ReadLine().Split(',',StringSplitOptions.RemoveEmptyEntries);
            char[,] field = FillMatrix(size);
            int shipsFirstPlayer = 0;
            int shipsSecondPlayer = 0;
            (shipsFirstPlayer, shipsSecondPlayer) = GetCountOfShips(field);
            int countOfShips = shipsFirstPlayer + shipsSecondPlayer;
            //body
            for (int i = 0; i < attacks.Length; i++)
            {
                int[] attack = attacks[i]
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = attack[0];
                int col = attack[1];
                if (ValidateIndex(row, col, field))
                {
                    (field, shipsFirstPlayer, shipsSecondPlayer) =
                        AttackSimulation(field, row, col, shipsFirstPlayer, shipsSecondPlayer);
                    if (shipsFirstPlayer == 0 || shipsSecondPlayer == 0)
                    {
                        break;
                    }
                }
            }
            if (shipsFirstPlayer > 0 && shipsSecondPlayer > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {shipsFirstPlayer} ships left. Player Two has {shipsSecondPlayer} ships left.");
            }
            else if (shipsFirstPlayer == 0 && shipsSecondPlayer > 0) //second player wins
            {
                Console.WriteLine($"Player Two has won the game! {countOfShips - (shipsFirstPlayer + shipsSecondPlayer)} ships have been sunk in the battle.");
            }
            else if (shipsSecondPlayer == 0 && shipsFirstPlayer > 0) //first plater wins
            {
                Console.WriteLine($"Player One has won the game! {countOfShips - (shipsFirstPlayer + shipsSecondPlayer)} ships have been sunk in the battle.");
            }

        }
        static char[,] FillMatrix(int size)
        {
            char[,] field = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string[] line = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = char.Parse(line[col]);
                }
            }
            return field;
        }
        static (int, int) GetCountOfShips(char[,] field)
        {
            int count1 = 0;
            int count2 = 0;
            foreach(var c in field)
            {
                if (c == '<')
                    count1++;
                if (c == '>')
                    count2++;
            }
            return (count1, count2);
        }
        static bool ValidateIndex(int row, int col, char[,] field)
        {
            bool valid = false;
            if (row > -1 && row < field.GetLength(0) && col > -1 && col < field.GetLength(1))
                valid = true;
            return valid;
        }
        static (char[,], int, int) AttackSimulation
            (char[,] field, int row, int col, int countOfShipsFP, int countOfShipsSP)
        {
            if (field[row, col] == '<')
            {
                field[row, col] = 'X';
                countOfShipsFP--;
            }
            else if (field[row, col] == '>')
            {
                field[row, col] = 'X';
                countOfShipsSP--;
            }
            else if (field[row, col] == '#')
            {
                (field, countOfShipsFP, countOfShipsSP) = Bomb(field, row, col, countOfShipsFP, countOfShipsSP);
                field[row, col] = 'X';
            }
            return (field, countOfShipsFP, countOfShipsSP);
        }
        static (char[,], int, int) Bomb(char[,] field, int row, int col, int countOfShipsFP, int countOfShipsSP)
        {
            if (ValidateIndex(row - 1, col - 1, field)) //upper left
            {
                if (field[row - 1, col - 1] == '<')
                    countOfShipsFP--;
                else if (field[row - 1, col - 1] == '>')
                    countOfShipsSP--;
                field[row - 1, col - 1] = 'X';
            }
            if (ValidateIndex(row - 1, col, field))
            {
                if (field[row - 1, col] == '<')
                    countOfShipsFP--;
                else if (field[row - 1, col] == '>')
                    countOfShipsSP--;
                field[row - 1, col] = 'X';
            }
            if (ValidateIndex(row - 1, col + 1, field))
            {
                if (field[row - 1, col + 1] == '<')
                    countOfShipsFP--;
                else if (field[row - 1, col + 1] == '>')
                    countOfShipsSP--;
                field[row - 1, col + 1] = 'X';
            }
            if (ValidateIndex(row, col - 1, field))
            {
                if (field[row, col - 1] == '<')
                    countOfShipsFP--;
                else if (field[row, col - 1] == '>')
                    countOfShipsSP--;
                field[row, col - 1] = 'X';
            }
            if (ValidateIndex(row, col + 1, field))
            {
                if (field[row, col + 1] == '<')
                    countOfShipsFP--;
                else if (field[row, col + 1] == '>')
                    countOfShipsSP--;
                field[row, col + 1] = 'X';
            }
            if (ValidateIndex(row + 1, col - 1, field))
            {
                if (field[row + 1, col - 1] == '<')
                    countOfShipsFP--;
                else if (field[row + 1, col - 1] == '>')
                    countOfShipsSP--;
                field[row + 1, col - 1] = 'X';
            }
            if (ValidateIndex(row + 1, col, field))
            {
                if (field[row + 1, col] == '<')
                    countOfShipsFP--;
                else if (field[row + 1, col] == '>')
                    countOfShipsSP--;
                field[row + 1, col] = 'X';
            }
            if (ValidateIndex(row + 1, col + 1, field))
            {
                if (field[row + 1, col + 1] == '<')
                    countOfShipsFP--;
                else if (field[row + 1, col + 1] == '>')
                    countOfShipsSP--;
                field[row + 1, col + 1] = 'X';
            }
            return (field, countOfShipsFP, countOfShipsSP);
        }
    }       
}
