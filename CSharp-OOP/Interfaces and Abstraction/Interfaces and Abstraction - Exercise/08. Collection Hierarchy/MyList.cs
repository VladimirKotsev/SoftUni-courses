namespace _08._Collection_Hierarchy
{
    using System.Collections.Generic;

    using Contracts;
    public class MyList : ICollection, IRemoveFromCollection
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string toReturn = this.collection[0];
            this.collection.RemoveAt(0);
            return toReturn;
        }

        public int Used => this.collection.Count;
    }
}
