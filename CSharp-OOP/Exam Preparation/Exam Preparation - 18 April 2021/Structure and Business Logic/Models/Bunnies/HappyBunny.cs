namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HappyBunnyInitialEnergy = 100;

        public HappyBunny(string name) : base(name, HappyBunnyInitialEnergy)
        {

        }
    }
}
