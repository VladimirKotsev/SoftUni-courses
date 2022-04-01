using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listToManipulate = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string givenCommand = Console.ReadLine();
            string command = null;
            while (givenCommand != "end")
            {
                string[] array = givenCommand.Split();
                command = array[0];
                switch (command)
                {
                    case "Contains": ContainsMethod(array, listToManipulate); break;
                    case "PrintEven": Console.WriteLine(String.Join(" ", PrintEvenMethod(listToManipulate))); break;
                    case "PrintOdd": Console.WriteLine(String.Join(" ", PrintOddMethod(listToManipulate))); break;
                    case "GetSum": Console.WriteLine(GetSum(listToManipulate)); break;
                    case "Filter": Console.WriteLine(String.Join(" ", GetFilteredList(listToManipulate, array))); break;
                    case "Add":
                        int n = int.Parse(array[1]);
                        listToManipulate.Add(n); break;
                    case "Remove":
                        n = int.Parse(array[1]);
                        listToManipulate.Remove(n); break;
                    case "RemoveAt":
                        n = int.Parse(array[1]);
                        listToManipulate.RemoveAt(n); break;
                    case "Insert":
                        n = int.Parse(array[1]);
                        int index = int.Parse(array[2]);
                        listToManipulate.Insert(index, n);
                        break;
                }
                givenCommand = Console.ReadLine();
            }
            if (command == "Add" || command == "Remove" || command == "RemoveAt" || command == "Insert")
            {
                Console.WriteLine(String.Join(" ", listToManipulate));
            }
        }
        static void ContainsMethod(string[] array, List<int> list)
        {
            int n = int.Parse(array[1]);
            if (list.Contains(n))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
        static List<int> PrintOddMethod(List<int> list)
        {
            List<int> oddList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 != 0)
                {
                    oddList.Add(list[i]);
                }
            }
            return oddList;
        }
        static List<int> PrintEvenMethod(List<int> list)
        {
            List<int> evenList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    evenList.Add(list[i]);
                }
            }
            return evenList;
        }
        static int GetSum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }
        static List<int> GetFilteredList(List<int> list, string[] array)
        {
            List<int> filteredList = new List<int>();
            string condition = array[1];
            int numberForCondition = int.Parse(array[2]);
            switch (condition)
            {
                case ">": filteredList = list.FindAll(x => x > numberForCondition); break;
                case "<": filteredList = list.FindAll(x => x < numberForCondition); break;
                case ">=": filteredList = list.FindAll(x => x >= numberForCondition); break;
                case "<=": filteredList = list.FindAll(x => x <= numberForCondition); break;
            }
            return filteredList;
        }
    }
}
