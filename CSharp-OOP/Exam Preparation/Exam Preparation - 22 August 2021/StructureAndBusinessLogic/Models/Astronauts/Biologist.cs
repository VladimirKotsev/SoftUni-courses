namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double oxygenBiologist = 70;

        public Biologist(string name) : base(name, oxygenBiologist)
        {

        }

        public override void Breath()
        {
            base.Oxygen -= 5;
        }
    }
}
