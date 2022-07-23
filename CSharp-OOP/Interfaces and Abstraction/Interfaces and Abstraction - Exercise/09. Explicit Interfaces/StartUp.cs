namespace _09._Explicit_Interfaces
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] person = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (person[0] != "End")
            {
                Citizen newCitizen = new Citizen(person[0], person[1], int.Parse(person[2]));
                newCitizen.GetName();

                person = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
