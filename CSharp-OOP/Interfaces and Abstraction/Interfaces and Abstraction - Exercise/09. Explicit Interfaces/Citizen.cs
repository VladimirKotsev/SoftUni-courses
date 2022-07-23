namespace _09._Explicit_Interfaces
{
    using System;
    using System.Text;
    public class Citizen : IPerson, IResident
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public int Age
        {
            get => age;
            set => age = value;
        }

        private string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public void GetName()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.Append($"Mr/Ms/Mrs {this.Name}");

            Console.WriteLine(sb);
        }
    }
}
