namespace Heroes.Models.Weapons
{
    using System;

    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

                name = value;
            }
        }

        private int durability;
        public int Durability
        {
            get { return durability; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }

                durability = value;
            }
        }

        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public abstract int DoDamage();

    }
}
