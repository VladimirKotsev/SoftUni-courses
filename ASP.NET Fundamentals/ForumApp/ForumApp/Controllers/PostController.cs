namespace ForumApp.Controllers
{
    using ForumApp.Models.Post;
    using Microsoft.AspNetCore.Mvc;
    public class PostController : Controller
    {
        private static readonly ICollection<KeyValuePair<string, string>> posts = new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult All()
        {
            if (posts.Count == 0)
            {
                return View(new ForumViewModel());
            }

            var viewModel = new ForumViewModel()
            {
                AllPosts = posts
                    .Select(x => new PostViewModel()
                    {
                        PostTitle = x.Key,
                        PostDescription = x.Value
                    })
                    .ToArray()
            };

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            //var postViewModel = posts.First(x => )

            return View(postViewModel);
        }

        [HttpGet]
        public IActionResult Add(PostViewModel postViewModel) 
        {
            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult AddPost(PostViewModel postViewModel)
        {
            posts.Add(new KeyValuePair<string, string>(postViewModel.PostTitle, postViewModel.PostDescription));

            return this.RedirectToAction("All");
        }
    }
}
