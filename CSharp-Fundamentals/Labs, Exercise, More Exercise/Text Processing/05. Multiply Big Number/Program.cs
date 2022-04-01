using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultipliresBigInteger();
        }
        static void MultipliresBigInteger()
        {
            string bigNumber = Console.ReadLine();
            if (bigNumber == string.Empty || bigNumber == null || bigNumber[0] == '0')
            {
                bigNumber = "0";
                int bigNum = int.Parse(bigNumber);
                Console.WriteLine(bigNum);
                return;
            }

            byte smallNumber = byte.Parse(Console.ReadLine());
            if (smallNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var bigNumAsChars = bigNumber.ToCharArray();
            double result = 0;
            StringBuilder reversedMultipliedResult = new StringBuilder();
            int remainder = 0;

            for (int i = bigNumAsChars.Length - 1; i >= 0; i--)
            {
                double currentDigit = char.GetNumericValue(bigNumAsChars[i]);
                result = currentDigit * smallNumber + remainder;

                if (i == 0)
                {
                    if (result >= 10)
                    {

                        string resultAsString = result.ToString();
                        //result = 89
                        char firstDigit = resultAsString[0]; //8
                        char secondDigit = resultAsString[1]; //9
                        string properResult = secondDigit.ToString() + firstDigit.ToString();//98 needed

                        reversedMultipliedResult.Append(properResult);
                        break;
                    }
                }
                if (result >= 10)
                {
                    currentDigit = result % 10;
                    remainder = (int)result / 10;
                    reversedMultipliedResult.Append(currentDigit.ToString());
                }
                else
                {
                    currentDigit = result;
                    remainder = 0;
                    reversedMultipliedResult.Append(currentDigit.ToString());
                }
            }

            StringBuilder properMultipliedResult = new StringBuilder();
            for (int i = reversedMultipliedResult.Length - 1; i >= 0; i--)
            {
                properMultipliedResult.Append(reversedMultipliedResult[i]);
            }

            Console.WriteLine(properMultipliedResult);
        }
    }
}
