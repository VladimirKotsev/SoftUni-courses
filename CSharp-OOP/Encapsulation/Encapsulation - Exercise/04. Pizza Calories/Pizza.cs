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
        private double totalCalories;
        public double TotalCalories
        {
            get { return totalCalories; }
            private set { totalCalories = value; }
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
        public IReadOnlyCollection<Topping> Toppings
        {
            get { return this.toppings.AsReadOnly(); }
        }

        public Pizza(string name)
        {
            this.Name = name; 
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
            this.TotalCalories = dough.CalculateDoughCalorie();
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count == 10)
            {
                throw new ArgumentException
                    ("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
            this.TotalCalories += topping.CalculateToppingCalorie();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }

    }
}
