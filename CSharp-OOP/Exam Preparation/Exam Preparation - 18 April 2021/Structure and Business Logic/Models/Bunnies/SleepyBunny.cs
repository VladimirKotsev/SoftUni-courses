using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SleepyBunnyInitialEnergy = 50;

        public SleepyBunny(string name) : base(name, SleepyBunnyInitialEnergy)
        {

        }

        public override void Work()
        {
            base.Energy -= 15;
        }
    }
}
