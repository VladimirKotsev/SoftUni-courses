using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator<string>.Create(5, "Pesho");
            int[] integers = ArrayCreator<int>.Create(10, 33);
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
