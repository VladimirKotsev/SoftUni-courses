namespace _03._Telephony
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] arrayOfPhoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in arrayOfPhoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone(phoneNumber);
                        Console.WriteLine(stationaryPhone.Call());
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone(phoneNumber);
                        Console.WriteLine(smartphone.Call());
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            string[] arrayOfURLs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string URL in arrayOfURLs)
            {
                try
                {
                    Smartphone smartphone = new Smartphone(URL, 1);
                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ae) 
                {
                    Console.WriteLine(ae.Message);
                }
            }

        }
    }
}
