namespace _07._Military_Elite.Models
{
    using Intefaces;
    public class Repair : IRepair
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

        private int hours;
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }
        }

        public Repair(string name, int hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.Hours}";
        }
    }
}
