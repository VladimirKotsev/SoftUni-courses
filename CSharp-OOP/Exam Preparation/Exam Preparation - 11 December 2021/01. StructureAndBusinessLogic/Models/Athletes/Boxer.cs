namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int StaminaForBoxer = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, StaminaForBoxer, numberOfMedals)
        {

        }

        public override void Exercise()
        {
            base.Stamina += 15;
        }
    }
}
