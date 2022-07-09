namespace _03._Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Smartphone : IBrowsable, ICallable
    {
        private string number;
        public string Number
        {
            get { return number; }
            private set
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
        private string url;

        public string URL
        {
            get { return url; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                }
                url = value;
            }
        }


        public Smartphone(string number)
        {
            this.Number = number;
        }

        public Smartphone(string url, int n)
        {
            this.URL = url;
        }

        public string Browse() => $"Browsing: {this.URL}!";

        public string Call() => $"Calling... {this.Number}";

    }
}
