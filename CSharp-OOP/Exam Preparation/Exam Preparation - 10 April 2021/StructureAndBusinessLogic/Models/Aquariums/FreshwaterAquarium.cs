namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int capacityFreshwaterAquarium = 50;

        public FreshwaterAquarium(string name) : base(name, capacityFreshwaterAquarium)
        {

        }
    }
}
