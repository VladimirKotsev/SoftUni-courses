namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double oxygenGeodist = 50;

        public Geodesist(string name) : base(name, oxygenGeodist)
        {

        }
    }
}
