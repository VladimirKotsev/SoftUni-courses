namespace _04._Pizza_Calories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private string typeOfTopping;
        public string TypeOfTopping
        {
            get { return typeOfTopping; }
            private set 
            {
                if (!ValidateTypeOfTopping(value.ToLower()))
                {
                    throw new ArgumentException
                        ($"Cannot place {value} on top of your pizza.");
                }
                typeOfTopping = value; 
            }
        }
        private int weight;
        public int Weight
        {
            get { return weight; }
            private set 
            { 
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException
                        ($"{this.TypeOfTopping} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public Topping(string typeOfTopping, int weight)
        {
            this.TypeOfTopping = typeOfTopping;
            this.Weight = weight;
        }

        private bool ValidateTypeOfTopping(string value)
        {
            if (value == "meat" || value == "veggies" || value == "cheese" || value == "sauce")
            {
                return true;
            }
            return false;
        }

        public double CalculateToppingCalorie()
        {
            double modifier = 0;

            switch (this.TypeOfTopping.ToLower())
            {
                case "meat": modifier = Meat; break;
                case "veggies": modifier = Veggies; break;
                case "cheese": modifier = Cheese; break;
                case "sauce": modifier = Sauce; break;
            }

            return this.Weight * modifier * 2;
        }

        public override string ToString()
        {
            return $"{CalculateToppingCalorie():f2}";
        }
    }
}
