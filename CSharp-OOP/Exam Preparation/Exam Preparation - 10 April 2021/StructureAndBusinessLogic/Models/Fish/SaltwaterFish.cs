namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int initialSizeSaltWaterFish = 5;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            base.Size = initialSizeSaltWaterFish;
        }

        public override void Eat()
        {
            base.Size += 2;
        }
    }
}
