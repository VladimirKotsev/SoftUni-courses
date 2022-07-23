namespace _07._Military_Elite.Models
{
    using Intefaces;
    public abstract class Soldier : ISoldier
    {
        private int id;
        public int Id 
        {
            get
            {
                return id;
            } 
            set
            {
                id = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public abstract override string ToString();
    }
}
