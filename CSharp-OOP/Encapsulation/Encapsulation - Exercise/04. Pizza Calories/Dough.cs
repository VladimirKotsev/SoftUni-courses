namespace _04._Pizza_Calories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Dough
    {
        private const double WhiteDough = 1.5;
        private const double WholegrainDough = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private string typeOfDough;
        public string TypeOfDough
        {
            get { return typeOfDough; }
            private set
            {
                if (!ValidateTypeOfDough(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                typeOfDough = value;
            }
        }
        private string bakingTech;
        public string BakingTech
        {
            get { return bakingTech; }
            private set
            {
                if (!ValidateTypeOfDough(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTech = value;
            }
        }

        private int weight;
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException
                        ("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public Dough(string typeOfDough, string bakingTechique, int weight)
        {
            this.TypeOfDough = typeOfDough;
            this.BakingTech = bakingTechique;
            this.Weight = weight;
        }

        public double CalculateDoughCalorie()
        {
            double modifier1 = 0;
            double modifier2 = 0;
            switch (this.TypeOfDough.ToLower())
            {
                case "white": modifier1 = WhiteDough; break;
                case "wholegrain": modifier1 = WholegrainDough; break;
            }
            switch (this.BakingTech.ToLower())
            {
                case "crispy": modifier2 = Crispy; break;
                case "chewy": modifier2 = Chewy; break;
                case "homemade": modifier2 = Homemade; break;
            }
            return (2 * this.Weight) * modifier1 * modifier2;
        }

        private bool ValidateTypeOfDough(string value)
        {
            if (value == "white" || value == "wholegrain"
                || value == "crispy" || value == "chewy" || value == "homemade")
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{CalculateDoughCalorie():f2}";
        }

    }
}
