namespace _04._Sum_of_Integers
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(' ');

            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    sum += int.Parse(array[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{array[i]:f2}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{array[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{array[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
