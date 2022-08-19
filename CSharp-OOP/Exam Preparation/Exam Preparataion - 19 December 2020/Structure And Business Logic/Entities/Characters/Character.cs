namespace WarCroft.Entities.Characters.Contracts
{
    using System;

    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;
    using WarCroft.Entities.Items;

    public abstract class Character
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        private double baseHealth;
        public double BaseHealth
        {
            get { return baseHealth; }
            protected set { baseHealth = value; }
        }

        private double health;
        public double Health
        {
            get { return health; }
            private set
            {
                if (value > this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }

                this.health = value;
            }
        }

        private double baseArmour;
        public double BaseArmour
        {
            get { return baseArmour; }
            protected set { baseArmour = value; }
        }

        private double armour;
        public double Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    armour = 0;
                }

                armour = value;
            }
        }

        private double abilityPoints;
        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        private IBag bag;
        public IBag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        public bool IsAlive { get; set; } = true;

        protected Character(string name, double health, double armour, double armourPoints, IBag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
            this.ArmourPoints = armourPoints;
            this.Bag = bag;
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armour >= hitPoints)
                {
                    this.Armour -= hitPoints;
                }
                else if (this.Armour < hitPoints)
                {
                    hitPoints -= this.Armour;
                    this.Armour = 0;
                    this.Health -= hitPoints;
                }

                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }

        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}