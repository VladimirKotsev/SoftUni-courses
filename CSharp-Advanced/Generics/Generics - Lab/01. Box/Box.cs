using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public Box()
        {
            this.data = new List<T>();
        }
        public void Add(T add)
        {
            this.data.Add(add);
        }
        public T Remove()
        {
            var lastElement = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return lastElement;
        }
    }
}
