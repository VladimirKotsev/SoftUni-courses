namespace ForumApp.Models.Post
{
    public class ForumViewModel
    {
        public ForumViewModel()
        {
            this.AllPosts = new HashSet<PostViewModel>();
        }

        public ICollection<PostViewModel> AllPosts { get; set; }

        public PostViewModel CurrentPost { get; set; } = null!;
    }
}
