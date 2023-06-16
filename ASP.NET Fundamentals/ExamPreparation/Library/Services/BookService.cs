namespace Library.Services
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models.Library;
    using Constrains;
    using Data.Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext libraryDbContext)
        {
            this.dbContext = libraryDbContext;
        }

        public async Task AddBookToAllAsync(AddBookViewModel addBookViewModel)
        {
            Book bookToAdd = new Book()
            {
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                Description = addBookViewModel.Description,
                ImageUrl = addBookViewModel.ImageUrl,
                Rating = addBookViewModel.Rating,
                CategoryId = addBookViewModel.CategoryId,
            };

            await dbContext.Books.AddAsync(bookToAdd);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToUserCollectionAsync(int bookId, string userId)
        {
            var bookIsAlreadyAdded = await dbContext
                .IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == bookId);
                    
            if (!bookIsAlreadyAdded)
            {
                var userBook = new IdentityUserBook()
                {
                    BookId = bookId,
                    CollectorId = userId,
                };

                await dbContext.IdentityUserBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<CategoryViewModel>> AddCategoryViewModelAsync()
        {
            var categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task<ICollection<BookViewModel>> GetAllBooksAsync()
        {
            var books = await dbContext.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name,
                    Description = b.Description
                })
                .ToListAsync();

            return books;
        }

        public async Task<ICollection<BookViewModel>> GetMyBooksAsync(string userId)
        {
            var books = await dbContext.IdentityUserBooks
                .Where(x => x.CollectorId == userId)
                .Select(b => new BookViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Rating = b.Book.Rating,
                    Category = b.Book.Category.Name,
                    Description = b.Book.Description
                })
                .ToListAsync();

            return books;
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var userBook = await dbContext
                .IdentityUserBooks
                .FirstAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);

            dbContext.IdentityUserBooks.Remove(userBook);
            await dbContext.SaveChangesAsync();
        }
    }
}
