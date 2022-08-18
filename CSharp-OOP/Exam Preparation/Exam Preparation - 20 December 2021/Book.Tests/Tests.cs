namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private const string bookName = "The secrets";
        private const string bookAuthor = "John Smith";

        [Test]
        public void TestConstructor()
        {
            Book book = new Book(bookName, bookAuthor);
            Assert.IsNotNull(book);
        }

        [Test]
        public void TestSettersThroughConstructor()
        {
            Book book = new Book(bookName, bookAuthor);

            Assert.AreEqual(book.BookName, bookName);
            Assert.AreEqual(book.Author, bookAuthor);
            Assert.AreEqual(book.FootnoteCount, 0);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestAuthorSetter_Exception(string parameter)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, parameter);
            },
            $"Invalid {parameter}!");
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestBookNameSetter_Exception(string parameter)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(parameter, bookAuthor);
            },
            $"Invalid {parameter}!");
        }

        [Test]
        public void TestCounterOfCollection()
        {
            Book book = new Book(bookName, bookAuthor);

            book.AddFootnote(124523, "Hello");

            Assert.AreEqual(book.FootnoteCount, 1);
        }

        [Test]
        public void TestAddMethod_Exception()
        {
            Book book = new Book(bookName, bookAuthor);

            book.AddFootnote(124523, "Hello");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(124523, "Hello");
            },
            "Footnote already exists!");
        }

        [Test]
        public void TestAddMethod()
        {
            Book book = new Book(bookName, bookAuthor);

            book.AddFootnote(124523, "Hello");
            book.AddFootnote(5421, "sgs");

            Assert.AreEqual(book.FootnoteCount, 2);
        }

        [Test]
        public void TestFindMethod_Exception()
        {
            Book book = new Book(bookName, bookAuthor);

            book.AddFootnote(20, "Hello");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(30);
            },
            "Footnote doesn't exists!");
        }

        [Test]
        public void TestFindMethod()
        {
            Book book = new Book(bookName, bookAuthor);

            book.AddFootnote(20, "Hello");
            string result = book.FindFootnote(20);

            Assert.AreEqual(result, $"Footnote #20: Hello");
        }

        [Test]
        public void TestAlterFootNote_Exception()
        {
            Book book = new Book(bookName, bookAuthor);


            book.AddFootnote(20, "Hello");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(30, "Edited text");
            },
            "Footnote does not exists!");
        }

        [Test]
        public void TestAlterFootNote()
        {
            Book book = new Book(bookName, bookAuthor);


            book.AddFootnote(20, "Hello");
            book.AlterFootnote(20, "Edited text");

            string result = book.FindFootnote(20);

            Assert.AreEqual(result, $"Footnote #20: Edited text");
        }
    }
}