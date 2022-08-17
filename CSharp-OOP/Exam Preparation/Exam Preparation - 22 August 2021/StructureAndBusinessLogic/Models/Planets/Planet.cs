namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using SpaceStation.Utilities.Messages;

    public class Planet : IPlanet
    {
        private List<string> items;
        public ICollection<string> Items
        {
            get { return items; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                name = value; 
            }
        }

        public Planet(string name)
        {
            this.items = new List<string>();
            this.Name = name;
        }
    }
}
