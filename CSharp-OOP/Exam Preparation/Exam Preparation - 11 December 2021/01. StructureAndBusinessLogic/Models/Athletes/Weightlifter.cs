namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int StaminaForWeightlifter = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, StaminaForWeightlifter, numberOfMedals)
        {

        }

        public override void Exercise()
        {
            base.Stamina += 10;
        }

    }
}
