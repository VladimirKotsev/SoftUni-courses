namespace BookShop
{
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //string cmd = Console.ReadLine();
            //int cmd = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booksNames = context.Books
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(x => x.Title)
                .ToList()
                .OrderBy(x => x);

            StringBuilder sb = new StringBuilder();
            foreach (var name in booksNames)
            {
                sb.AppendLine(name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldType = "Gold";
            var countOfCopies = 5000;

            var bookNames = context.Books
                .Where(x => x.EditionType.ToString() == goldType && x.Copies < countOfCopies)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var name in bookNames)
            {
                sb.AppendLine(name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var minimumPrice = 40;

            var books = context.Books
                .Where(x => x.Price > minimumPrice)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context.Books
                .Where(x => x.ReleaseDate != null && x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var bookTitles = context.Books
                .Where(x => x.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(x => x.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var bookAuthors = context.Authors
                .Where(b => b.FirstName.EndsWith(input))
                .Select(b => b.FirstName + " " + b.LastName)
                .OrderBy(b => b)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in bookAuthors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in bookAuthors)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return books.Length;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(b => b.Copies);

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryBooks.Where(cb => cb.CategoryId == c.CategoryId).Sum(b => b.Book.Copies * b.Book.Price))
                .ThenBy(c => c.Name)
                .Select(c => $"{c.Name} ${c.CategoryBooks.Where(cb => cb.CategoryId == c.CategoryId).Sum(b => b.Book.Copies * b.Book.Price):f2}")
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine(category);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Where(cb => cb.CategoryId == c.CategoryId)
                    .OrderByDescending(x => x.Book.ReleaseDate)
                    .Take(3)
                    .Select(x => x.Book)
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine("--" + category.Name);

                foreach(var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate!.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToChange = context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in booksToChange)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int count = booksToDelete.Length;

            context.RemoveRange(booksToDelete);

            context.SaveChanges();

            return count;
        }
    }
}


