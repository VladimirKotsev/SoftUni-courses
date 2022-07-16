namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Cat : Animal
    {
        public Cat(string name, string favFood) : base(name, favFood)
        {

        }

        public override string ExplainSelf()
        {
            return $"I am {base.Name} and my favourite food is {base.FavouriteFood}{Environment.NewLine}MEEOW"; 
        }

    }
}
