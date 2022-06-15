using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02._Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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
        public void PrintAll()
        {
            foreach (T item in this.collection)
            {
                Console.Write(item + " ");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
