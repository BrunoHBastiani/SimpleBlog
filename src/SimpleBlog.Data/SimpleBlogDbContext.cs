using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data
{
    public class SimpleBlogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public SimpleBlogDbContext(DbContextOptions<SimpleBlogDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity &&
                    (x.State == EntityState.Added ||
                     x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var now = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).RegisterEntity();
                }

                ((BaseEntity)entry.Entity).UpdateEntity();
            }
        }
    }
}
