using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public static class ArrayCreator<T>
    {
        public static T[] Create(int length, T item)
        {
            var array = new T[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = item;
            }
            return array;
        }
    }
}
