using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public Library(params Book[] books) 
        {
            this.books = new List<Book>(books);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                Console.WriteLine(this.books[i]);
                yield return this.books[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = books.ToList();

            }
            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {

            }
            public bool MoveNext()
            {
                return ++this.currentIndex < books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }

        }
    }
}
