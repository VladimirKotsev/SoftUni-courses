namespace ForumApp.Controllers
{
    using ForumApp.Services.Contracts;
    using ForumApp.ViewModels.Post;
    using Microsoft.AspNetCore.Mvc;
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            this.postService = _postService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PostListViewModel> allPosts = await this.postService.ListAllAsync();

            return View(allPosts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel _model)
        {
            //posts.Add(new KeyValuePair<string, string>(postViewModel.PostTitle, postViewModel.PostDescription));

            if (!ModelState.IsValid)
            {
                return View(_model);
            }

            try
            {
                await this.postService.AddPostAsync(_model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

                return View(_model);
            }

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                PostFormModel postViewModel = await this.postService.GetForEditOrDeleteByIdAsync(id);

                return View(postViewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel _postFormModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(_postFormModel);
            }

            try
            {
                await this.postService.EditByIdAsync(id, _postFormModel);
            }
            catch (Exception)
            {
                return View(_postFormModel);
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.postService.DeleteByIdAsync(id);
            }
            catch (Exception)
            {

            }

            return RedirectToAction("All");
        }
    }
}
