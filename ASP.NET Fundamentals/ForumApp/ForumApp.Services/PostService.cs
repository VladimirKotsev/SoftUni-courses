
namespace ForumApp.Services
{

    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts;
    using ViewModels.Post;
    using Data.Models;

    public class PostService : IPostService
    {
        private readonly ForumDbContext dbContext;

        public PostService(ForumDbContext _dbContext)
        {
                this.dbContext = _dbContext;
        }

        public async Task AddPostAsync(PostFormModel postAddViewModel)
        {
            Post post = new Post()
            {
                Title = postAddViewModel.Title,
                Content = postAddViewModel.Content,
            };

            await dbContext.Posts.AddAsync(post);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Post postToDelete = await this.dbContext
                .Posts
                .FirstAsync(post => post.Id == id);

            this.dbContext.Posts.Remove(postToDelete);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditByIdAsync(int id, PostFormModel postEditModel)
        {
            Post postToEdit = await this.dbContext
                .Posts
                .FirstAsync(p => p.Id == id);

            postToEdit.Title = postEditModel.Title;
            postToEdit.Content = postEditModel.Content;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<PostFormModel> GetForEditOrDeleteByIdAsync(int id)
        {
            Post postToEdit = await dbContext
                .Posts
                .FirstAsync(p => p.Id == id);

            return new PostFormModel()
            {
                Title = postToEdit.Title,
                Content = postToEdit.Content,
            };   
        }

        public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await dbContext
                .Posts
                .Select(p => new PostListViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToArrayAsync();

            return allPosts;
        }
    }
}
