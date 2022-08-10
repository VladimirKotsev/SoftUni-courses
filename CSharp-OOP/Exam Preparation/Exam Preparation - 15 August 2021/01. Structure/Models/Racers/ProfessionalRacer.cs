using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DrivingExperienceForProfessionalRacer = 30;
        private const string RacingBehaiviorForProfessionalRacer = "strict";

        private const int IncreaseOnDrivingExpForProfessionalDriver = 10;

        public ProfessionalRacer(string username, ICar car) 
            : base(username, RacingBehaiviorForProfessionalRacer, DrivingExperienceForProfessionalRacer, car)
        {

        }

        public override void Race()
        {
            base.Race();
            base.DrivingExperience += IncreaseOnDrivingExpForProfessionalDriver;
        }
    }
}
