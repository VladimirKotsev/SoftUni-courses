namespace Gym.Models.Equipment
{
    using System;

    using Contracts;
    public abstract class Equipment : IEquipment
    {
        private double weight;
        public double Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        private decimal price;
        public decimal Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }
    }
}
