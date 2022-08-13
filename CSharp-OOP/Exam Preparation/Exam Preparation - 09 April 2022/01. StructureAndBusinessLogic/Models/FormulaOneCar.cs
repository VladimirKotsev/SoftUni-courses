namespace Formula1.Models
{
    using System;

    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                model = value;
            }
        }

        private int horsepower;
        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                horsepower = value;
            }
        }

        private double engineDisplacemet;
        public double EngineDisplacement
        {
            get { return engineDisplacemet; }
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                engineDisplacemet = value;
            }
        }

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public double RaceScoreCalculator(int laps)
        {
            return this.EngineDisplacement / this.Horsepower * laps;
        }
    }
}
