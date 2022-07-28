namespace _08._Collection_Hierarchy
{
    using System.Collections.Generic;

    using Contracts;
    public class AddCollection : ICollection
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
