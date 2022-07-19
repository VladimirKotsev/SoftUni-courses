namespace Raiding.Models
{
    
    public abstract class BaseHero
    {
        private string name;
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            {
                name = value; 
            }
        }
        private int power;
        public int Power
        {
            get 
            { 
                return power; 
            }
            set 
            { 
                power = value;
            }
        }

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public abstract string CastAbility();

        public override string ToString()
        {
            return CastAbility();
        }
    }
}
