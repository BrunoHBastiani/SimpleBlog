using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid?> CreateAsync(User user);
        Task<User?> GetByIdAsync(Guid userId);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    }
}
