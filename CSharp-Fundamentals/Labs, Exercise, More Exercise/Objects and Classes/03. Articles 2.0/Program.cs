using System;
using System.Linq;

namespace _03._Articles_2._0
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
        public void Print()
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article myArticle = new Article(input[0], input[1], input[2]);
                myArticle.Print();
            }
            string inTheMiddleOfNowhere = Console.ReadLine();
        }
    }
}
