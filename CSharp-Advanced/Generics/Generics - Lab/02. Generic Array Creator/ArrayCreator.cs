﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Generic_Array_Creator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
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
