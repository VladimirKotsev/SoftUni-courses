namespace NavalVessels.Models
{

    using System.Text;

    using Contracts;
    public class Submarine : Vessel, ISubmarine
    {
        private const double ArmourThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, ArmourThickness)
        {
            this.SubmergeMode = false;
        }

        private bool submergeMode;
        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }
        public override void RepairVessel()
        {
            base.ArmorThickness = ArmourThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.SubmergeMode)
            {
                sb.AppendLine($"*Submerge mode: ON");
            }
            else
            {
                sb.AppendLine($"*Submerge mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                base.MainWeaponCaliber -= 40;
                base.Speed += 4;
                this.SubmergeMode = false;
            }
            else
            {
                base.MainWeaponCaliber += 40;
                base.Speed -= 4;
                this.SubmergeMode = true;
            }
        }
    }
}
