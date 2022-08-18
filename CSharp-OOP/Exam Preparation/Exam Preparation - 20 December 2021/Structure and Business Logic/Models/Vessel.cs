namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                name = value;
            }
        }

        private ICaptain captain;
        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                captain = value;
            }
        }

        private double armourThickness;
        public double ArmorThickness
        {
            get { return armourThickness; }
            set 
            { 
                if (value < 0)
                {
                    value = 0;
                }
                armourThickness = value; 
            }
        }

        private double mainWeaponCaliber;
        public double MainWeaponCaliber 
        {
            get
            {
                return mainWeaponCaliber;
            }
            set
            {
                mainWeaponCaliber = value;
            }
        }

        private double speed;
        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        private List<string> targets;
        public ICollection<string> Targets
        {
            get { return targets; }
        }

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }

        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            this.targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");

            if (this.targets.Count == 0)
            {
                sb.AppendLine($"*Targets: none");
            }
            else
            {
                sb.AppendLine($"*Targets: {String.Join(", ", this.targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
