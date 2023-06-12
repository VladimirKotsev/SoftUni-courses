using System.Reflection;

namespace ForumApp.Data.Seeding
{
    using Models;

    internal class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "This is my first post. I hope you like it!"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post, you might like this one better!"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Best of my three posts!"
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
