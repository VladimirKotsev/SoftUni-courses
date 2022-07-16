namespace _05._Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pet : IBirthable, INamable
    {
        public string Name { get; set; }

        public string Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
    }
}
