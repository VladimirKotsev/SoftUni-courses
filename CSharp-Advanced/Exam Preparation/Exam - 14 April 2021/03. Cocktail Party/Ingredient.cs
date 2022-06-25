using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int alcohol;
        public int Alcohol
        {
            get { return alcohol; }
            set { alcohol = value; }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Ingredient: {Name}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Alcohol: {Alcohol}";
        }

    }
}
