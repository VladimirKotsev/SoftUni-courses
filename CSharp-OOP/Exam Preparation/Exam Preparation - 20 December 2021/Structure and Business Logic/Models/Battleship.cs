namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;
    public class Battleship : Vessel, IBattleship
    {
        private const double ArmourThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, ArmourThickness)
        {
            this.SonarMode = false;
        }

        private bool sonarMode;
        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                base.MainWeaponCaliber -= 40;
                base.Speed += 5;
                this.SonarMode = false;
            }
            else
            {
                base.MainWeaponCaliber += 40;
                base.Speed -= 5;
                this.SonarMode = true;
            }
        }

        public override void RepairVessel()
        {
            base.ArmorThickness = ArmourThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.SonarMode)
            {
                sb.AppendLine($"*Sonar mode: ON");
            }
            else
            {
                sb.AppendLine($"*Sonar mode: OFF");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
