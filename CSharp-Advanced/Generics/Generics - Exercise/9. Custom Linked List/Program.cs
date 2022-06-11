using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(2);
            list.AddFirst(1);

            list.AddLast(3);
            list.AddFirst(4);
            list.AddLast(5);
            list.RemoveLast();
            list.RemoveFirst();

        }
    }
}
