using Library.Models.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Constrains
{
    public interface IBookService
    {
        public Task<ICollection<BookViewModel>> GetAllBooksAsync();

        public Task<ICollection<BookViewModel>> GetMyBooksAsync(string userId);

        public Task AddBookToUserCollectionAsync(int bookId, string userId);

        public Task<ICollection<CategoryViewModel>> AddCategoryViewModelAsync();

        public Task AddBookToAllAsync(AddBookViewModel addBookViewModel);

        public Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}
