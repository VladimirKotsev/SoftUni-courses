namespace _08._Collection_Hierarchy
{
    using System.Collections.Generic;

    using Contracts;
    public class AddRemoveCollection : ICollection, IRemoveFromCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
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
            string toReturn = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);
            return toReturn;
        }
    }
}
