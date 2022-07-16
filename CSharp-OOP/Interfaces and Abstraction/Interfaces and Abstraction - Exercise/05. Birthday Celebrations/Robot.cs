namespace _05._Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Robot : IPersonable
    {
        public string Model { get; set; }
        public string Id { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
