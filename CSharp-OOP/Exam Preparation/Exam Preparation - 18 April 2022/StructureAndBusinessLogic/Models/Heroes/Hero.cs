namespace Heroes.Models.Heroes
{
    using System;

    using Contracts;
    public abstract class Hero : IHero
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                name = value;
            }
        }

        private int health;
        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                health = value;
            }
        }

        private int armour;
        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                armour = value;
            }
        }

        private IWeapon weapon;
        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                weapon = value;
            }
        }

        public bool IsAlive
        {
            get { return this.Health > 0; }
        }

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (this.Armour > 0 && this.Armour >= points)
            {
                this.Armour -= points;
            }
            else if (this.Armour > 0 && this.Health >= points - this.Armour)
            {
                points -= this.Armour;
                this.Armour = 0;
                this.Health -= points;
            }
            else if (this.Armour == 0 && this.Health >= points)
            {
                this.Health -= points;
            }
            else
            {
                this.Health = 0;
            }
        }
    }
}
