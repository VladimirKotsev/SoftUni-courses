using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Generic_Swap_Method_Integers
{
    public class Box<T>
    {
        public List<T> List { get; set; }

        public Box()
        {
            List = new List<T>();
        }

        public void Swap(int index1, int index2)
        {
            var helper = this.List[index1];
            this.List[index1] = List[index2];
            this.List[index2] = helper;
        }

        public void Print()
        {
            foreach (var item in this.List)
                Console.WriteLine($"{typeof(T)}: {item}");
        }
    }
}
