﻿using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.Reset();
            }

            public Book Current => this.books[index];


            object IEnumerator.Current => this.Current;


            public bool MoveNext()
            {
                this.index++;
                return this.index < this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
