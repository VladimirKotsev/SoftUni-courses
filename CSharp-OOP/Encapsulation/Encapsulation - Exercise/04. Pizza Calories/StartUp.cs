namespace _04._Pizza_Calories
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            string[] array = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            while(array[0] != "END")
            {
                Dough pizza = new Dough(array[1], array[2], int.Parse(array[3]));
                Console.WriteLine($"{pizza.Calculate():f2}");
                array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
