﻿namespace _06._Food_Shortage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rebel : INamable, IBuyer
    {
        public string Name { get; set ; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; } = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }

    }
}
