namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class PostController : Controller
    {
        private static readonly ICollection<KeyValuePair<string, string>> posts = new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult All()
        {
            if (posts.Count == 0)
            {
                return View();
            }

            //var viewModel = new ForumViewModel()
            //{
            //    AllPosts = posts
            //        .Select(x => new PostViewModel()
            //        {
            //            PostTitle = x.Key,
            //            PostDescription = x.Value
            //        })
            //        .ToArray()
            //};

            return View();
        }

        public IActionResult Edit(int id)
        {
            //var postViewModel = posts.First(x => )

            return View();
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost()
        {
            //posts.Add(new KeyValuePair<string, string>(postViewModel.PostTitle, postViewModel.PostDescription));

            return this.RedirectToAction("All");
        }
    }
}
