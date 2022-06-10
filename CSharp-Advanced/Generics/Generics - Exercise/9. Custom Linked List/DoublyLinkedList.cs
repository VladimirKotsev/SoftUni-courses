using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private List<T> data;
        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }

        public DoublyLinkedList()
        {
            this.Data = new List<T>();
        }
        public int Count()
        { return this.Data.Count(); }
        public bool Contains(T element)
        {
            {return Data.Contains(element); }
        }
        public void AddFirst(T element)
        { Data.Insert(0, element); }
        public void AddLast(T element)
        { Data.Insert(Count() - 1, element); }
        public void RemoveFirst()
        { Data.RemoveAt(0); }
        public void RemoveLast()
        { Data.RemoveAt(Count() - 1); }


        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public void Remove(T element)
        {
            if (Count() == 0)
            {
                throw new ArgumentException("List is empty");
            }
            if (Contains(element))
                Data.Remove(element);
            else
                throw new ArgumentException("List does not contain such element");
        }
        public void RemoveAt(int index)
        { 
            if (Count() == 0 || index < 0 || index > Count() - 1)
            {
                throw new ArgumentException("Index out of range");
            }
            Data.RemoveAt(index);
        }

        public void ForEach(Action<T> action)
        {
            foreach(T d in Data)
            {
                
            }
        }
    }
}
