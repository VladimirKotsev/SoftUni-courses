using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public Library(List<Book> books) 
        {
            this.books = new List<Book>(books);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }
        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            return currentIndex + 1 < books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        //private class LibraryIterator : IEnumerator<Book>
        //{
        //    private readonly List<Book> books;
        //    private int currentIndex;

        //    public LibraryIterator(IEnumerable<Book> books)
        //    {
        //        this.Reset();
        //        this.books = books.ToList();

        //    }

        //    public Book Current => this.books[currentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
                
        //    }
        //    public bool MoveNext()
        //    {
        //        return currentIndex + 1 < books.Count;
        //    }

        //    public void Reset()
        //    {
        //        this.currentIndex = -1;
        //    }

        //}
    }
}
