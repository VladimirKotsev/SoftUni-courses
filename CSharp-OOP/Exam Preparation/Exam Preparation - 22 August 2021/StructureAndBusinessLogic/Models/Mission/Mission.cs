namespace SpaceStation.Models.Mission
{

    using Contracts;
    using Models.Astronauts.Contracts;
    using Models.Planets.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (true)
                {
                    if (!astronaut.CanBreath || planet.Items.Count == 0)
                    {
                        break;
                    }

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(planet.Items.First());
                    planet.Items.Remove(planet.Items.First());
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
