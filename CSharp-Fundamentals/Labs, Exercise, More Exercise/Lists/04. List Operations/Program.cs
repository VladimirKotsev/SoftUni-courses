using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string manipulation = Console.ReadLine();
            while (manipulation != "End")
            {
                string[] command = manipulation.Split(" " ,StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "Add":
                        list.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        if (int.Parse(command[2]) > list.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        }
                        break;

                    case "Remove":
                        if (int.Parse(command[1]) > list.Count - 1)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.RemoveAt(int.Parse(command[1]));
                        }
                        break;
                    case "Shift":
                        if (command[1] == "left")
                        {
                            list = ShiftLeftMethod(list, int.Parse(command[2]));
                        }
                        else
                        {
                            list = ShiftRightMethod(list, int.Parse(command[2]));
                        }
                        break;
                }
                manipulation = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", list));
        }
        //static List<int> AddMethod(List<int> list, int number)
        //{
        //    list.Add(number);
        //    return list;
        //}
        //static List<int> InsertMethod(List<int> list, int index, int number)
        //{
        //    list.Insert(index, number);
        //    return list;
        //}
        //static List<int> RemoveMethod(List<int> list, int index)
        //{
        //    list.RemoveAt(index);
        //    return list;
        //}
        static List<int> ShiftLeftMethod(List<int> list, int count)
        {
            for (int j = 1; j <= count; j++)
            {
                int firstIndex = list[0];
                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i] = list[i + 1];
                }
                list[list.Count - 1] = firstIndex;
            }
            return list;
        }
        static List<int> ShiftRightMethod(List<int> list, int count)
        {
            for (int j = 1; j <= count; j++)
            {
                int lastIndex = list[list.Count - 1];
                for (int i = list.Count - 1; i >= 1; i--)
                {
                    list[i] = list[i - 1];
                }
                list[0] = lastIndex;
            }
            return list;
        }
    }
}
