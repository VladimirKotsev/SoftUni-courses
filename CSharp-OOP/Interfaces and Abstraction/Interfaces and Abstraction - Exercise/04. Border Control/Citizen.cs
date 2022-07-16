namespace _04._Border_Control
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Citizen : IPersonable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
