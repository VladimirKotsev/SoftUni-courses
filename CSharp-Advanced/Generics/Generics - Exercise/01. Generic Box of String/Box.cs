using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Box_of_String
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
