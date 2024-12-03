using SimpleBlog.Data.Filters;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data.Interfaces
{
    public interface IPostRepository
    {
        Task<Guid?> CreateAsync(Post post);
        Task<Post?> UpdateAsync(Post post);
        Task<Post?> GetByIdAsync(Guid postId);
        Task<IEnumerable<Post>> GetAsync(PostFilter postFilter);
        Task DeleteAsync(Post post);
    }
}
