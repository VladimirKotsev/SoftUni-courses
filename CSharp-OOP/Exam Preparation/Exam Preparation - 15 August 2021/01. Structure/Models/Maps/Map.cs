namespace CarRacing.Models.Maps
{
    using System;

    using CarRacing.Models.Racers.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class Map : IMap
    {
        private const double RacingBehaviorMultiplier_Strict = 1.20;
        private const double RacingBehaviorMultiplier_Aggressive = 1.10;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return String.Format(
                    OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable() && racerOne.IsAvailable())
            {
                return String.Format(
                    OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            double behaviorMultiplierOfRacerOne = 0;
            double behaviorMultiplierOfRacerTwo = 0;

            switch (racerOne.RacingBehavior)
            {
                case "strict":
                    behaviorMultiplierOfRacerOne = RacingBehaviorMultiplier_Strict; break;
                case "aggressive":
                    behaviorMultiplierOfRacerOne = RacingBehaviorMultiplier_Aggressive; break;
            }
            switch (racerTwo.RacingBehavior)
            {
                case "strict":
                    behaviorMultiplierOfRacerTwo = RacingBehaviorMultiplier_Strict; break;
                case "aggressive":
                    behaviorMultiplierOfRacerTwo = RacingBehaviorMultiplier_Aggressive; break;
            }

            double chanceOfRacerOneWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * behaviorMultiplierOfRacerOne;
            double chanceOfRacerTwoWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * behaviorMultiplierOfRacerTwo;

            if (chanceOfRacerOneWinning > chanceOfRacerTwoWinning)
            {
                racerOne.Race();
                racerTwo.Race();

                return String.Format(
                    OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();
                return String.Format(
                    OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }

        }
    }
}
