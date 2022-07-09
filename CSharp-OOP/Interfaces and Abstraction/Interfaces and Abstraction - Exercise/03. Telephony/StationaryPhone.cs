namespace _03._Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class StationaryPhone : ICallable
    {
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    char c = value[i];
                    if (!Char.IsDigit(c))
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                number = value;
            }
        }

        public StationaryPhone(string number)
        {
            this.Number = number;
        }

        public string Call()
        => $"Dialing... {this.Number}";
    }
}
