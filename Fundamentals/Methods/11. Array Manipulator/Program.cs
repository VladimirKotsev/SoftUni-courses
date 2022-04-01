using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] toDo = input.Split();
                string command = toDo[0];

                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(toDo[1]);
                        array = ExchangeMethod(array, index); break;

                    case "min":
                        if (toDo[1] == "even")
                        {
                            GetMinEven(array);
                        }
                        else if (toDo[1] == "odd")
                        {
                            GetMinOdd(array);
                        }
                        break;

                    case "max":
                        if (toDo[1] == "even")
                        {
                            GetMaxEven(array);
                        }
                        else if (toDo[1] == "odd")
                        {
                            GetMaxOdd(array);
                        }
                        break;

                    case "first":
                        int count = int.Parse(toDo[1]);
                        if (toDo[2] == "even")
                        {
                            GetFirstEvenNumbers(array, count);
                        }
                        else if (toDo[2] == "odd")
                        {
                            GetFirstOddNumbers(array, count);
                        }
                        break;

                    case "last":
                        int count1 = int.Parse(toDo[1]);
                        if (toDo[2] == "even")
                        {
                            GetLastEvenNumbers(array, count1);
                        }
                        else if (toDo[2] == "odd")
                        {
                            GetLastOddNumbers(array, count1);
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("[" + String.Join(", ", array) + "]");
        }
        static int[] ExchangeMethod(int[] array, int index)
        {
            if (index - 1 > array.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return array;
            }
            int[] arrayTemplate = new int[array.Length];
            int j = 1;
            int z = 0;
            for (int i = 0; index + j < array.Length; i++, j++)
            {
                arrayTemplate[i] = array[index + j];
            }
            for (int k = j - 1; k < array.Length; k++, z++)
            {
                arrayTemplate[k] = array[z];
            }
            array = arrayTemplate;
            return array;
        }
        static void GetMinEven(int[] array)
        {
            int min = int.MaxValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] <= min)
                {
                    min = array[i];
                    index = i;
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
        static void GetMaxEven(int[] array)
        {
            int max = int.MinValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] >= max)
                {
                    max = array[i];
                    index = i;
                }
            }
            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
        static void GetMinOdd(int[] array)
        {
            int min = int.MaxValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] <= min)
                {
                    min = array[i];
                    index = i;
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
        static void GetMaxOdd(int[] array)
        {
            int max = int.MinValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
        static void GetFirstEvenNumbers(int[] array, int count)
        {
            if (count >= array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] returnArray = new int[count];
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                for (int k = j; j < array.Length; j++)
                {
                    if (array[j] % 2 == 0)
                    {
                        returnArray[i] = array[j];
                        break;
                    }
                }
                j++;
            }
            if (returnArray == null)
            {
                Console.WriteLine("[]");
            }
            else
            {
                for (int i = 0; i < returnArray.Length; i++)
                {
                    string s = returnArray[i].ToString();
                    Console.WriteLine("[" + String.Join(", ", returnArray.Where(String.IsNullOrEmpty(s))) + "]");
                }
            }
        }
        static void GetFirstOddNumbers(int[] array, int count)
        {
            if (count >= array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] returnArray = new int[count];
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                for (int k = j; j < array.Length; j++)
                {
                    if (array[j] % 2 != 0)
                    {
                        returnArray[i] = array[j];
                        break;
                    }
                }
                j++;
            }
            if (returnArray == null)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", returnArray) + "]");
            }
        }
        static void GetLastEvenNumbers(int[] array, int count)
        {
            if (count >= array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] returnArray = new int[count];
            int j = array.Length - 1;
            for (int i = 0; i < count; i++)
            {
                for (int k = j; j >= 0; j--)
                {
                    if (array[j] % 2 == 0)
                    {
                        returnArray[i] = array[j];
                        break;
                    }
                }
                j--;
            }
            if (returnArray != null)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", returnArray) + "]");
            }
        }
        static void GetLastOddNumbers(int[] array, int count)
        {
            if (count >= array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] returnArray = new int[count];
            int j = array.Length - 1;
            for (int i = 0; i < count; i++)
            {
                for (int k = j; j >= 0; j--)
                {
                    if (array[j] % 2 != 0)
                    {
                        returnArray[i] = array[j];
                        break;
                    }
                }
                j--;
            }
        }

        //static int GetNumberInString(string convert)
        //{
        //    string getNum = string.Empty;
        //    foreach (char c in convert)
        //    {
        //        if (char.IsDigit(c))
        //        {
        //            getNum = c.ToString();
        //            break;
        //        }
        //    }
        //    int num = int.Parse(getNum);
        //    return num;
        //}
    }
}
