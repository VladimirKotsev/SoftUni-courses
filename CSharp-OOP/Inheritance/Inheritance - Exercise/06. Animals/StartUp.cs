namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                try
                {
                    string type = Console.ReadLine();
                    if (type == "Beast!")
                    { break; }
                    string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = null;
                    if (type == "Animal")
                    {
                    }
                    else if (type == "Cat")
                    { animal = new Cat(info[0], int.Parse(info[1]), info[2]); }
                    else if (type == "Dog")
                    { animal = new Dog(info[0], int.Parse(info[1]), info[2]); }
                    else if (type == "Frog")
                    { animal = new Frog(info[0], int.Parse(info[1]), info[2]); }
                    else if (type == "Kitten")
                    { animal = new Kitten(info[0], int.Parse(info[1])); }
                    else if (type == "Tomcat")
                    { animal = new Tomcat(info[0], int.Parse(info[1])); }
                    else
                    {
                        throw new ArgumentException("Invalid type!");
                    }

                    animals.Add(animal);

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
