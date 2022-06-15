using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03._Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> Data { get; set; }

        public Stack()
        {
            this.Data = new List<T>();
        }

        public void Push(params T[] element)
        {
            for (int i = 0; i < element.Length; i++)
            {
                this.Data.Insert(this.Data.Count, element[i]);
            }
        }
        public T Pop()
        {
            if (this.Data.Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            T result = this.Data[Data.Count - 1];
            Data.RemoveAt(Data.Count - 1);
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
