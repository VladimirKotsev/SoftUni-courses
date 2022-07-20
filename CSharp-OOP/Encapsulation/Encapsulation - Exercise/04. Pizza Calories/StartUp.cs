namespace _04._Pizza_Calories
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;

            int numberOfToppings = 0;

            while (true)
            {
                string[] arrayInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (arrayInput[0] == "END")
                    {
                        break;
                    }

                    if (arrayInput[0] == "Pizza")
                    {
                        pizza = new Pizza(arrayInput[1]);
                    }
                    else if (arrayInput[0] == "Dough")
                    {
                        Dough dough = new Dough(arrayInput[1], arrayInput[2], int.Parse(arrayInput[3]));
                        pizza.Dough = dough;
                    }
                    else if (arrayInput[0] == "Topping")
                    {
                        Topping topping = new Topping(arrayInput[1], int.Parse(arrayInput[2]));
                        numberOfToppings++;

                        if (numberOfToppings > 10)
                        {
                            throw new ArgumentException("Number of toppings should be in range [0..10].");
                        }

                        pizza.AddTopping(topping);
                    }

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
