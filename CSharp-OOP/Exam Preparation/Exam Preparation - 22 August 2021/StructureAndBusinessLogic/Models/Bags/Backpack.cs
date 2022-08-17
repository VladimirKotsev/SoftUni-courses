namespace SpaceStation.Models.Bags
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    public class Backpack : IBag
    {
        private List<string> items;
        public ICollection<string> Items
        {
            get { return items; }
        }

        public Backpack()
        {
            this.items = new List<string>();
        }
    }
}
