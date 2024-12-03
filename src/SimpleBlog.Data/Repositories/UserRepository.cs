using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data.Interfaces;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimpleBlogDbContext _context;

        public UserRepository(SimpleBlogDbContext context)
        {
            _context = context;
        }

        public async Task<Guid?> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
    }
}
