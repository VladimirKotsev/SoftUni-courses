namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double WeightOfBoxingGloves = 227;
        private const decimal PriceOfBoxingGloves = 120;

        public BoxingGloves() 
            : base(WeightOfBoxingGloves, PriceOfBoxingGloves)
        {

        }
    }
}
