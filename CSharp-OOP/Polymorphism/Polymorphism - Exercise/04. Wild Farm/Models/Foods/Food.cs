namespace WildFarm.Models
{
    public abstract class Food
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

    }
}
