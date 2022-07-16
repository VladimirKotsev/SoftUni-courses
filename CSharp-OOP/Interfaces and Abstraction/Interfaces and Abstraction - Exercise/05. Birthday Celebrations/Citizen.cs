namespace _05._Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Citizen : IPersonable, IBirthable, INamable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
    }
}
