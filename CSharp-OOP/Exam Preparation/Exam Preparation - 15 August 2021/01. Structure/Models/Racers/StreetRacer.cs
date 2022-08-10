using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DrivingExperienceForStreeRacer = 10;
        private const string RacingBehaiviorForStreetRacer = "aggressive";

        private const int IncreaseOnDrivingExpForStreetDriver = 5;

        public StreetRacer(string username, ICar car) 
            : base(username, RacingBehaiviorForStreetRacer, DrivingExperienceForStreeRacer, car)
        {

        }

        public override void Race()
        {
            base.Race();
            base.DrivingExperience += IncreaseOnDrivingExpForStreetDriver;
        }
    }
}
