namespace PersonInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private string name;
        public string Name { get => this.name; set => name = value; }
        private int age;
        public int Age { get => this.age; set => age = value; }
        private string id;
        public string Id { get => this.id; set => id = value; }
        private string birthdate;
        public string Birthdate { get => this.birthdate; set => birthdate = value; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
