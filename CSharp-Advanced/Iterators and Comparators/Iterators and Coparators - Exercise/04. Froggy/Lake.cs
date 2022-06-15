using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04._Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] Data { get; set; }

        public Lake(params int[] rocks)
        {
            this.Data = rocks;
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (this.Data.Length % 2 == 0)
            {
                for (int i = 0; i < Data.Length; i+= 2)
                {
                    yield return Data[i];
                }
                for (int i = Data.Length - 1; i >= 0; i -= 2)
                {
                    yield return Data[i];
                }
            }
            else
            {
                for (int i = 0; i < Data.Length; i += 2)
                {
                    yield return Data[i];
                }
                for (int i = Data.Length - 2; i >= 0; i -= 2)
                {
                    yield return Data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
