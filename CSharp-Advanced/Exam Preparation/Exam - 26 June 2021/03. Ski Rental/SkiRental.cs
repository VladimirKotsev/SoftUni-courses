using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public int Count
        {
            get { return this.data.Count; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public void Add(Ski ski)
        {
            if (this.data.Count + 1 <= this.Capacity)
                this.data.Add(ski);
        }
        public bool Remove(string manufacturer, string model)
        {
            bool remove = false;
            int index = 0;

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i].Manufacturer == manufacturer && this.data[i].Model == model)
                {
                    remove = true;
                    index = i;
                    break;
                }
            }

            if (remove == true)
                this.data.RemoveAt(index);

            return remove;
        }
        public Ski GetNewestSki()
        {
            int index = -1;
            int max = 0;

            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i].Year > max)
                {
                    max = this.data[i].Year;
                    index = i;
                }
            }

            if (index == -1)
                return null;

            return this.data[index];
        }
        public Ski GetSki(string manufacturer, string model) // might fail
        {
            return this.data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:\n" +
                   String.Join(Environment.NewLine, this.data);
        }

    }
}
