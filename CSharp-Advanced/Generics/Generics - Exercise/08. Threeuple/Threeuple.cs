using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Threeuple
{
    public class Threeuple<Titem1, Titem2, Titem3>
    {
        public Titem1 item1 { get; set; }
        public Titem2 item2 { get; set; }

        public Titem3 item3 { get; set; }

        public Threeuple(Titem1 item1, Titem2 item2, Titem3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
