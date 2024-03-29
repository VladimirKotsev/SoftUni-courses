﻿namespace _06._Food_Shortage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Citizen : IIdentiable, IBirthable, INamable, IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; } = 0;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
