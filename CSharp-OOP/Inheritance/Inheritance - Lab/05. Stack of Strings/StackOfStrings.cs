using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (base.Count == 0)
            {
                return true;
            }
            return false;
        }
        public void AddRange(IEnumerable<string> collection)
        {
            foreach(var c in collection)
            {
                base.Push(c);
            }
        }
    }
}
