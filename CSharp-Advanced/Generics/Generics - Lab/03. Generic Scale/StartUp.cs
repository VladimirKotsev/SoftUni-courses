using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> newScale = new EqualityScale<int>(5 ,5);
            Console.WriteLine(newScale.AreEqual());
            EqualityScale<string> newScale1 = new EqualityScale<string>("p", "P");
            Console.WriteLine(newScale1.AreEqual());
        }
    }
}
