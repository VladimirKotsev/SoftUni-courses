namespace CarRacing.Models.Cars
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class Car : ICar
    {

        private string make;
        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                make = value;
            }
        }

        private string model;
        public string Model
        {
            get { return this.model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                model = value;
            }
        }

        private string vin;
        public string VIN
        {
            get { return this.vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                vin = value;
            }
        }

        private int horsePower;
        public int HorsePower
        {
            get { return this.horsePower; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                horsePower = value;
            }

        }

        private double fuelAvailable;
        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set
            {
                if (value <= 0)
                {
                    fuelAvailable = 0;
                }

                fuelAvailable = value;
            }
        }

        private double fuelConsumptionPerRace;
        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                fuelConsumptionPerRace = value;
            }
        }

        protected Car(string make, string model, string vIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public virtual void Drive()
        {
            this.FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
