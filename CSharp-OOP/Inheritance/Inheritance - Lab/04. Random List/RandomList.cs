using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            int index = new Random().Next(0, base.Count - 1);
            base.RemoveAt(index);
            return base[index].ToString();
        }
    }
}
