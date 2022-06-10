using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int numberOfBadges = 0;

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        private List<Pokemon> collection = new List<Pokemon>();

        public List<Pokemon> Collection
        {
            get { return collection; }
            set { collection = value; }
        }

        public Trainer()
        {

        }

        public Trainer(string name, string pokemonName, string pokemonElement, int pokemonHealth)
        {
            this.Name = name;
            Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            this.Collection.Add(newPokemon);
        }

        public Trainer CheckForGivenElement(Trainer trainer, string element)
        {
            bool check = false; // not equal to element
            foreach(var poke in trainer.Collection)
            {
                if (poke.Element == element)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
                trainer.Collection = ReduceHealthOfPokemons(trainer.Collection);
            else
                trainer.NumberOfBadges++;
            return trainer;

        }

        private List<Pokemon> ReduceHealthOfPokemons(List<Pokemon> pokemons)
        {
            int count = pokemons.Count;
            for (int i = 0; i < count; i++)
            {
                pokemons[i].Health -= 10;
                if (pokemons[i].Health <= 0)
                {
                    pokemons.RemoveAt(i);
                    i--;
                    count--;
                }
            }
            return pokemons;
        }

        public void PrintOut(List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.collection.Count}");
            }
        }
    }
}
