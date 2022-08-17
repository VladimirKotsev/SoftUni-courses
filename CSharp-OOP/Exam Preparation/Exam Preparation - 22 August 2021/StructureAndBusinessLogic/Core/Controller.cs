namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Repositories;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Utilities.Messages;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Mission.Contracts;
    using System.Text;

    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int planetsExplored;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                IAstronaut astronaut = new Biologist(astronautName);

                this.astronauts.Add(astronaut);
            }
            else if (type == "Geodesist")
            {
                IAstronaut astronaut = new Geodesist(astronautName);

                this.astronauts.Add(astronaut);
            }
            else if (type == "Meteorologist")
            {
                IAstronaut astronaut = new Meteorologist(astronautName);

                this.astronauts.Add(astronaut);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            
            foreach(var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            var suitable = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (suitable.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();

            mission.Explore(planet, suitable);
            planetsExplored++;

            return String.Format(
                OutputMessages.PlanetExplored, 
                planetName, 
                suitable.Where(x => !x.CanBreath).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.planetsExplored} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {String.Join(", ", astronaut.Bag.Items)}");
                }

            }

            return sb.ToString().TrimEnd();
        }
    }
}
