using ForumApp.ViewModels.Post;

namespace ForumApp.Services.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostFormModel postAddViewModel);

        Task<PostFormModel> GetForEditOrDeleteByIdAsync(int id);

        Task EditByIdAsync(int id, PostFormModel postEditModel);

        Task DeleteByIdAsync(int id);
    }
}
