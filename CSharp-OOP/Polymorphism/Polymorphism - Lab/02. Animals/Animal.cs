namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Animal
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string favouriteFood;
        public string FavouriteFood
        {
            get { return favouriteFood; }
            set { favouriteFood = value; }
        }
        public Animal(string name, string favFood)
        {
            this.Name = name;
            this.FavouriteFood = favFood;
        }

        public abstract string ExplainSelf();

    }
}
