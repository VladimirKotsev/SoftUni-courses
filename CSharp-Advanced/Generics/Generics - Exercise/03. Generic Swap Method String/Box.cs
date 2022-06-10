using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Generic_Swap_Method_String
{
    public class Box<T>
    {
        public List<T> Data { get; set; }

        public Box()
        {
            Data = new List<T>();
        }

        public void Swap(int index1, int index2)
        {
            var helper = Data[index1];
            Data[index1] = Data[index2];
            Data[index2] = helper;
        }
        public void Print()
        {
            foreach(var s in Data)
            {
                Console.WriteLine($"{typeof(T)}: {s}");
            }
        }
    }
}
