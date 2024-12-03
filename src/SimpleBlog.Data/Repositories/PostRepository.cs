using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data.Filters;
using SimpleBlog.Data.Interfaces;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SimpleBlogDbContext _context;

        public PostRepository(SimpleBlogDbContext context)
        {
            _context = context;
        }

        public async Task<Guid?> CreateAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post.Id;
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post?> GetByIdAsync(Guid postId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<IEnumerable<Post>> GetAsync(PostFilter postFilter)
        {
            var query = _context.Posts
                .Include(p => p.User)
                .AsNoTracking()
                .AsQueryable();

            if (postFilter.UserId != null) 
                query = query.Where(p => p.UserId == postFilter.UserId);

            if (!string.IsNullOrEmpty(postFilter.Title)) 
                query = query.Where(p => p.Title.ToLower().Contains(postFilter.Title.ToLower()));

            if (!string.IsNullOrEmpty(postFilter.Content))
                query = query.Where(p => p.Content.ToLower().Contains(postFilter.Content.ToLower()));

            return await query.ToListAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
