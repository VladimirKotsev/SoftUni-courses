using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _06._Generic_Count_Method_Double
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public T Element { get; set; }
        public List<T> Elements { get; set; }

        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elemntsList)
        {
            Elements = elemntsList;
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int CountOFGreaterElements<T>(List<T> list, T readLine) where T : IComparable
            => list.Count(word => word.CompareTo(readLine) > 0);
    }
}
