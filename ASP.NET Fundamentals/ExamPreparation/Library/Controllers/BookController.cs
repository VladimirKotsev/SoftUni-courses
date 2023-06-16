namespace Library.Controllers
{
    using Library.Models.Library;
    using Library.Services.Constrains;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services;
    using System.Security.Claims;

    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        public BookController(IBookService _bookService)
        {
            this.bookService = _bookService;
        }

        public async Task<IActionResult> All()
        {
            var allBooks = await bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        public async Task<IActionResult> Mine()
        {

            var allBooks = await bookService.GetMyBooksAsync(this.UserId);

            return View(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            await bookService.AddBookToUserCollectionAsync(id, this.UserId);

            return RedirectToAction("All", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            await bookService.RemoveFromCollectionAsync(id, this.UserId);

            return RedirectToAction("Mine", "Book");
        }

        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel()
            {
                Categories = await bookService.AddCategoryViewModelAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBookToAllAsync(bookViewModel);

                return RedirectToAction("All", "Book");
            }

            return View(bookViewModel);
        }
    }
}
