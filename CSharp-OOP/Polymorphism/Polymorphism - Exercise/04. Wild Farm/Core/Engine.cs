namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Intefaces;
    using Factory;
    using Factory.Intefaces;
    using Models.Animals;
    using Models.Foods;
    public class Engine : IEngine
    {
        public void Start()
        {
            List<Animal> animals = new List<Animal>();

            Animal animal = null;
            Food food = null;

            while (true)
            {
                string[] animalInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (animalInput[0] == "End")
                { break; }

                string[] foodInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                animal = BuildAnimalUsingFactory(animalInput);

                IFactoryFood foodFactory = new FactoryFood();
                food = foodFactory.CreateFood(foodInput[0], int.Parse(foodInput[1]));


                if (animal.PreferredFoods.Contains(food.GetType()))
                    animal.FoodEaten += int.Parse(foodInput[1]);
                else
                    Console.WriteLine
                        ($"{animal.GetType().Name} does not eat {food.GetType().Name}!");

                animals.Add(animal);

            }

            foreach (var ani in animals)
            {
                Console.WriteLine(ani);
            }
        }
        public Animal BuildAnimalUsingFactory(string[] animalInput)
        {
            Animal animal = null;

            IFactoryAnimal animalFactory = new FactoryAnimal();

            if (animalInput.Length == 5)
            {
                animal = animalFactory.CreateAnimal
                    (animalInput[0], animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);
            }
            else if (animalInput.Length == 4)
            {
                animal = animalFactory.CreateAnimal
                (animalInput[0], animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
            }

            return animal;
        }
    }
}
