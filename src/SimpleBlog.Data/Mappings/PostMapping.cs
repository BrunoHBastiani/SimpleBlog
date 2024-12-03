using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data.Mappings
{
    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts");

            builder.HasKey(post => post.Id);

            builder.Property(post => post.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(post => post.Content)
                .HasColumnName("content")
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(post => post.User).WithMany(user => user.Posts).HasForeignKey(post => post.UserId);
        }
    }
}
