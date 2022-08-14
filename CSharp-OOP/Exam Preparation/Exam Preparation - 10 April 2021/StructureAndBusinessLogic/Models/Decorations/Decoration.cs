namespace AquaShop.Models.Decorations
{
    using System;

    using Contracts;
    using Utilities.Messages;
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        public int Comfort
        {
            get { return comfort; }
            private set { comfort = value; }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }

        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }
    }
}
