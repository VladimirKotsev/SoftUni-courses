namespace Raiding.Factory
{
    using System;
    using Models;
    using Models.Heroes;
    using Intefaces;

    public class Factory : IFactory
    {
        public BaseHero CreateClass(string type, string name)
        {
            BaseHero baseHero = null;

            switch(type)
            {
                case "Druid":
                    baseHero = new Druid(name);
                    break;
                case "Paladin":
                    baseHero = new Paladin(name);
                    break;
                case "Rogue":
                    baseHero = new Rogue(name);
                    break;
                case "Warrior":
                    baseHero = new Warrior(name);
                    break;
                default: 
                    Console.WriteLine("Invalid hero!"); 
                    break;
            }

            return baseHero;
        }
    }
}
