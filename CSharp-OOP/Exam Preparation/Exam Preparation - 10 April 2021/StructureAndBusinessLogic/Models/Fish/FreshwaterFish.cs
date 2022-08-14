namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int initialSizeFreshWaterFish = 3;

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            base.Size = initialSizeFreshWaterFish;
        }

        public override void Eat()
        {
            base.Size += 3;
        }
    }
}
