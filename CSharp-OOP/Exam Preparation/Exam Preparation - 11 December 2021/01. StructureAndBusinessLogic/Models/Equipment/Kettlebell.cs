namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double WeightOfKettlebell = 10000;
        private const decimal PriceOfKettlebell = 80;

        public Kettlebell() 
            : base(WeightOfKettlebell, PriceOfKettlebell)
        {

        }
    }
}
