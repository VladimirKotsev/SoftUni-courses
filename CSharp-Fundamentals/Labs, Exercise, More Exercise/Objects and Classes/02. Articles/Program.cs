using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public void EditMethod(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public void Rename(string title)
        {
            this.Title = title;
        }
        public void Output()
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();
            int count = int.Parse(Console.ReadLine());
            Article myArticle = new Article(list[0], list[1], list[2]);
            for(int i = 1; i <= count; i++)
            {
                string[] toDo = Console.ReadLine().Split(": ");
                switch (toDo[0])
                {
                    case "Edit": myArticle.EditMethod(toDo[1]); break;
                    case "ChangeAuthor": myArticle.ChangeAuthor(toDo[1]); break;
                    case "Rename": myArticle.Rename(toDo[1]); break;
                }
            }
            myArticle.Output();
        }
    }
}
