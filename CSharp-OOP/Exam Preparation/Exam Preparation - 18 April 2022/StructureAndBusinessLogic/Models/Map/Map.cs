namespace Heroes.Models.Map
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(x => x.GetType().Name == "Knight").ToList();
            List<IHero> barbarians = players.Where(x => x.GetType().Name == "Barbarian").ToList();

            while (!knights.All(x => x.IsAlive == false) || !barbarians.All(x => x.IsAlive == false))
            {

                foreach (var knight in knights.Where(x => x.IsAlive == true))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive == true))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                if (knights.All(x => x.IsAlive == false) || barbarians.All(x => x.IsAlive == false))
                {
                    break;
                }

                foreach (var barbarian in barbarians.Where(x => x.IsAlive == true))
                {
                    foreach (var knight in knights.Where(x => x.IsAlive == true))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            List<IHero> knightsDead = knights.Where(x => x.Health == 0).ToList();

            List<IHero> barbariansDead = barbarians.Where(x => x.Health == 0).ToList();


            if (barbarians.All(x => x.IsAlive == false))
            {
                return $"The knights took {knightsDead.Count} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbariansDead.Count} casualties but won the battle.";
            }
        }
    }
}
