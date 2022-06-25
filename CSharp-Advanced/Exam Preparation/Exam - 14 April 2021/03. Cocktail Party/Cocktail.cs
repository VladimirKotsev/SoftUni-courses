using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private int alcohol;
        private List<Ingredient> collection;
        public List<Ingredient> Collection
        {
            get { return collection; }
            set { collection = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        private int maxAlcoholLevel;
        public int MaxAlcoholLevel
        {
            get { return maxAlcoholLevel; }
            set { maxAlcoholLevel = value; }
        }
        public int CurrentAlcoholLevel { get { return this.alcohol; } }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Collection = new List<Ingredient>();
        }

        public bool AlreadyExistingIngredient(Ingredient ingredient)
        {
            bool check = false;
            foreach (var i in this.Collection)
            {
                if (i.Name == ingredient.Name)
                {
                    check = true; 
                }
            }
            return check;
        } 
        // true -> exists // false -> isn't existing
        public bool ValidateIngredient(Ingredient ingredient) 
        {
            bool check = false;
            if (this.Capacity - 1 >= 0 && ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                check = true;
            }
            return check;
        }
        // yes -> Everything is good;; // no -> not good


        public void Add(Ingredient ingredient)
        {
            if (!AlreadyExistingIngredient(ingredient))
            {
                if (ValidateIngredient(ingredient))
                {
                    this.Collection.Add(ingredient);
                    this.alcohol += ingredient.Alcohol;
                    this.Capacity--;
                }
            }
        }
        public bool Remove(string name)
        {
            bool result = false;
            for (int i = 0; i < this.Collection.Count; i++)
            {
                if (this.Collection[i].Name == name)
                {
                    this.Capacity++;
                    this.alcohol -= this.Collection[i].Alcohol;
                    this.Collection.RemoveAt(i);  
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Ingredient FindIngredient(string name) // might fail !!!!!!!
        {
            return this.Collection.Find(x => x.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < this.Collection.Count; i++)
            {
                if (this.Collection[i].Alcohol > max)
                {
                    max = this.Collection[i].Alcohol;
                    index = i;
                }
            }
            return this.Collection[index];
        }
        public string Report()
        {
            return $"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}\n" +
                   $"{String.Join(Environment.NewLine, this.Collection)}";
        }
    }
}
