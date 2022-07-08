namespace _04._Pizza_Calories
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;

            try
            {
                string[] arrayForPizza = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                pizza = new Pizza(arrayForPizza[1]);

                string[] doughArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Dough dough = new Dough(doughArray[1], doughArray[2], int.Parse(doughArray[3]));

                pizza = new Pizza(arrayForPizza[1], dough);


            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            while (true)
            {
                string[] toppingArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);  

                if (toppingArray[0] == "END")
                {
                    break;
                }

                try
                {
                    Topping currentTopping = new Topping(toppingArray[1], int.Parse(toppingArray[2]));

                    pizza.AddTopping(currentTopping);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }         
            }

            Console.WriteLine(pizza);

        }
    }
}
