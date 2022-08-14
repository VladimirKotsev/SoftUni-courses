namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int comfortOfPlant = 5;
        private const int priceOfPlant = 10;

        public Plant() : base(comfortOfPlant, priceOfPlant)
        {

        }
    }
}
