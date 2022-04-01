using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string givenPassword = Console.ReadLine();
            CheckForValidation(givenPassword);
        }
        static bool CheckLengthOfPassword(string pass)
        {
            int length = pass.Length;
            bool IsLengthOK = false;
            if (length >= 6 && length <= 10)
            {
                IsLengthOK = true;
            }
            return IsLengthOK;
        }
        static bool CheckForLettersAndDigits(string pass)
        {
            bool IsLettersAndDigitsOK = false;
            foreach (char c in pass)
            {
                if (c >= 48 && c <= 57 || c >=65 && c <= 90 || c >= 97 && c <= 122)
                {
                    IsLettersAndDigitsOK = true;
                }
                else
                {
                    return false;
                }
            }
            return IsLettersAndDigitsOK;
        }
        static bool ChechForDigits(string pass)
        {
            int count = 0;
            bool IsDigitsOK = false;
            foreach (char c in pass)
            {
                if (c >= 48 && c <= 57)
                {
                    count++;
                }
            }
            if (count >= 2)
            {
                IsDigitsOK = true;
            } 
            return IsDigitsOK;
        }
        static void CheckForValidation(string pass)
        {
            if (ChechForDigits(pass) && CheckLengthOfPassword(pass) && CheckForLettersAndDigits(pass))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!CheckLengthOfPassword(pass))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!CheckForLettersAndDigits(pass))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!ChechForDigits(pass))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }
    }
}
