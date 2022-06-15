using System;
using System.Collections.Generic;
using System.Text;

namespace _01._ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        public int currIndex;

        public ListyIterator(params T[] data)
        {
            this.collection = new List<T>(data);
            this.currIndex = 0;
        }
        public bool HasNext() => currIndex + 1 < this.collection.Count;

        public bool Move()
        {
            bool check = HasNext();
            if (check)
                currIndex++;
            return check;
        }
        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(collection[currIndex]);
        }
    }
}
