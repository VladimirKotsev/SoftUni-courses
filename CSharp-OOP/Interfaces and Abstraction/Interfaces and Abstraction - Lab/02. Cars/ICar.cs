namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        string Start();
        string Stop();
    }
}
