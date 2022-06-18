using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
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
        private List<Racer> racers;
        public List<Racer> Racers
        {
            get { return racers; }
            set { racers = value; }
        }
        public int Count 
        {
            get
            {
                return racers.Count;
            }
        }

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Racers = new List<Racer>();
        }

        public void Add(Racer racer)
        {
            if (this.Racers.Count + 1 <= capacity)
                this.Racers.Add(racer);
        }
        public bool Remove(string name)
        {
            return this.Racers.Remove(this.Racers.Find(x => x.Name == name));
        }
        public Racer GetOldestRacer()
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < this.Racers.Count; i++)
            {
                if (this.Racers[i].Age > max)
                {
                    max = this.Racers[i].Age;
                    index = i;
                }
            }
            return this.Racers[index];
        }
        public Racer GetRacer(string name)
        {
            return this.Racers.Find(x => x.Name == name);
        }
        public Racer GetFastestRacer()
        {
            int index = 0;
            int max = 0;
            for (int i = 0; i < this.Racers.Count; i++)
            {
                if (this.Racers[i].Car.Speed > max)
                {
                    max = this.Racers[i].Car.Speed;
                    index = i;
                }
            }
            return this.Racers[index];
        }
        public string Report()
        {
            return
                $"Racers participating at {this.Name}:{Environment.NewLine}" +
                  String.Join(Environment.NewLine, this.Racers);
        }
    }
}
