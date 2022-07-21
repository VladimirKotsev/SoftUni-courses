namespace _06._Money_Transactions
{
    using System;
    using System.Collections.Generic;
    public class InsufficientBalanceException : Exception
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, decimal> accounts = new Dictionary<int, decimal>();

            string[] array = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (string account in array)
            {
                string[] split = account.Split('-');
                accounts.Add(int.Parse(split[0]), decimal.Parse(split[1]));
            }

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "End")
            {
                try
                {
                    int accNumber = int.Parse(input[1]);
                    decimal money = decimal.Parse(input[2]);
                    if (input[0] == "Deposit")
                    {
                        accounts[accNumber] += money;

                        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                    }
                    else if (input[0] == "Withdraw")
                    {
                        if (accounts[accNumber] < money)
                        { throw new InsufficientBalanceException(); }

                        accounts[accNumber] -= money;
                        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                    }
                    else
                    { throw new ArgumentException("Invalid command!"); }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (InsufficientBalanceException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
