using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Generic_Box_of_Integers
{
    public class Box<T>
    {
        private T data;
        public Box(T item)
        {
            this.data = item;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {data}";
        }
    }
}
