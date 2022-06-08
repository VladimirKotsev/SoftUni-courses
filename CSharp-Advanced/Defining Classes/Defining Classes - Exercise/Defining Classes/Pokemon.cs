using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string element;
        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        private int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.Name = pokemonName;
            this.Element = pokemonElement;
            this.Health = pokemonHealth;
        }
    }
}
