using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(user => user.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(user => user.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasMany(user => user.Posts).WithOne(post => post.User).HasForeignKey(post => post.UserId);
        }
    }
}
