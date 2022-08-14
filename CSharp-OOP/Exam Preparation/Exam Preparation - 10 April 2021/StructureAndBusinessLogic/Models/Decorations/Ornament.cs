namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int comfortOfOrnament = 1;
        private const int priceOfOrnament = 5;

        public Ornament() 
            : base(comfortOfOrnament, priceOfOrnament)
        {

        }
    }
}
