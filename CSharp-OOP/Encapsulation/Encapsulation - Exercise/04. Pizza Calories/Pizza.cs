namespace _04._Pizza_Calories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pizza
    {
        private Dough dough;
        public Dough Dough 
        { 
            get {  return dough; }
            set {  dough = value; }
        }
        private double toppingCalories;
        public double ToppingCalories
        {
            get { return toppingCalories; }
            private set { toppingCalories = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            { 
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException
                        ("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name; 
            this.toppings = new List<Topping>();
        }


        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException
                    ("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
            this.ToppingCalories += topping.CalculateToppingCalorie();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.ToppingCalories + this.Dough.CalculateDoughCalorie():f2} Calories.";
        }

    }
}
