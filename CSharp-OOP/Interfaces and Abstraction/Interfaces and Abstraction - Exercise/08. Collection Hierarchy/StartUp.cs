namespace _08._Collection_Hierarchy
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> firstCollInfo = new List<int>();
            List<int> secondCollInfo = new List<int>();
            List<int> thirdCollInfo = new List<int>();

            List<string> removeFirstColl = new List<string>();
            List<string> removeSecondColl = new List<string>();

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in input)
            {
                firstCollInfo.Add(addCollection.Add(s));
                secondCollInfo.Add(addRemoveCollection.Add(s));
                thirdCollInfo.Add(myList.Add(s));
            }

            int nOperations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nOperations; i++)
            {
                removeFirstColl.Add(addRemoveCollection.Remove());
                removeSecondColl.Add(myList.Remove());
            }

            Console.WriteLine(String.Join(' ', firstCollInfo));
            Console.WriteLine(String.Join(' ', secondCollInfo));
            Console.WriteLine(String.Join(' ', thirdCollInfo));
            Console.WriteLine(String.Join(' ', removeFirstColl));
            Console.WriteLine(String.Join(' ', removeSecondColl));
        }

    }
}
