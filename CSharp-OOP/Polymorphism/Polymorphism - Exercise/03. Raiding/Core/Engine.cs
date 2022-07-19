namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Heroes;
    using Factory;
    public class Engine : IEngine
    {
        private List<BaseHero> heroes = new List<BaseHero>();
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                Factory heroFactory = new Factory();
                BaseHero hero = heroFactory.CreateClass(type, name);

                if (hero != null)
                    heroes.Add(hero);

            }
            int powerOfBoss = int.Parse(Console.ReadLine());
            int powerOfHeroes = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero);
                powerOfHeroes += hero.Power;
            }

            if (powerOfHeroes >= powerOfBoss)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
