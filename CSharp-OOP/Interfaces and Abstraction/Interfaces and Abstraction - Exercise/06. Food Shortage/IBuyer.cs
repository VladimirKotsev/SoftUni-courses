namespace _06._Food_Shortage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IBuyer
    {
        public int Food { get; set; }
        public void BuyFood();
    }
}
