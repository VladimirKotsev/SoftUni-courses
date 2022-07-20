namespace WildFarm.Factory
{
    using System;
    using Intefaces;
    using Models.Animals;
    using Models.Animals.Birds;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;

    public class FactoryAnimal : IFactoryAnimal
    {
        public Animal CreateAnimal(string type, string name, double weight, params string[] leftovers)
        {
            Animal animal = null;

            switch (type)
            {
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(leftovers[0]));
                    break;
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(leftovers[0]));
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, leftovers[0]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, leftovers[0]);
                    break;
                case "Cat":
                    animal = new Cat(name, weight, leftovers[0], leftovers[1]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, leftovers[0], leftovers[1]);
                    break;
            }

            Console.WriteLine(animal.ProduceSound());

            return animal;
        }
    }
}
