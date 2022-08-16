namespace Easter.Models.Dyes
{
    using System;

    using Contracts;
    public class Dye : IDye
    {
        private int power;
        public int Power
        {
            get { return power; }
            private set
            {
                if (value < 0)
                {
                    power = 0;
                }

                power = value;
            }
        }

        public Dye(int power)
        {
            this.Power = power;
        }

        public void Use()
        {
            this.Power -= 10;
        }
        public bool IsFinished()
        {
             return this.Power == 0;
        }
    }
}
