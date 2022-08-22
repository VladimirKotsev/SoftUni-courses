namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double priceOfNuclearWeapon = 15;

        public NuclearWeapon(int destructionLevel) 
            : base(destructionLevel, priceOfNuclearWeapon)
        {

        }
    }
}
