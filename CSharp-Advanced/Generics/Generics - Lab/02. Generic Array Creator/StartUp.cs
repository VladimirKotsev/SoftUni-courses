﻿using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var strings = ArrayCreator.Create(5, "Pesho");
            var integers = ArrayCreator.Create(10, 33);
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }
            foreach(var i in integers)
            {
                Console.WriteLine(i);
            }
        }
    }
}
