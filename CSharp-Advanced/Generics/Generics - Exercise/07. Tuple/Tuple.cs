using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Tuple
{
    public class Tuple<Titem1, Titem2>
    {
        public Titem1 item1 { get; set; }
        public Titem2 item2 { get; set; }

        public Tuple(Titem1 item1, Titem2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }

}
