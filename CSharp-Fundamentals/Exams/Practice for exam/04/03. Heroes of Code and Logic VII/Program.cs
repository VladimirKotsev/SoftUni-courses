using System;
using System.Collections.Generic;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class HeroStats
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public HeroStats(int hp, int mp)
        {
            this.HP = hp;
            this.MP = mp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HeroStats> heroes = new Dictionary<string, HeroStats>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] newHeroes = Console.ReadLine().Split(' ');
                HeroStats newHero = new HeroStats(int.Parse(newHeroes[1]), int.Parse(newHeroes[2]));
                heroes.Add(newHeroes[0], newHero);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmd = command.Split(" - ");
                string heroName = cmd[1];
                switch(cmd[0])
                {
                    case "CastSpell": 
                        int MPCost = int.Parse(cmd[2]); 
                        string spellName = cmd[3];
                        if (heroes[heroName].MP >= MPCost)
                        {
                            heroes[heroName].MP -= MPCost;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        } break;
                        
                    case "TakeDamage":
                        int damage = int.Parse(cmd[2]);
                        string attacker = cmd[3];
                        if (heroes[heroName].HP > damage)
                        {
                            heroes[heroName].HP -= damage;
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        } break;

                    case "Recharge":
                        int amount = int.Parse(cmd[2]);
                        if (heroes[heroName].MP + amount <= 200)
                        {
                            heroes[heroName].MP += amount;
                            Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        }
                        else
                        {
                            int leftAmount = 200 - heroes[heroName].MP;
                            heroes[heroName].MP += leftAmount;
                            Console.WriteLine($"{heroName} recharged for {leftAmount} MP!");
                        } break;

                    case "Heal":
                        int amount2 = int.Parse(cmd[2]);
                        if (heroes[heroName].HP + amount2 <= 100)
                        {
                            heroes[heroName].HP += amount2;
                            Console.WriteLine($"{heroName} healed for {amount2} HP!");
                        }
                        else
                        {
                            int leftAmount2 = 100 - heroes[heroName].HP;
                            heroes[heroName].HP += leftAmount2;
                            Console.WriteLine($"{heroName} healed for {leftAmount2} HP!");
                        } break;
                }
                command = Console.ReadLine();
            }
            foreach(var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }  
    }
}
