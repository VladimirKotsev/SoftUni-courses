namespace PersonInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Citizen : IPerson
    {
        private string name;
        public string Name { get => this.name; set => name = value; }
        private int age;
        public int Age { get => this.age; set => age = value; }

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
