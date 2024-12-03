namespace SimpleBlog.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User? User { get; set; } = null;

        public Post(Guid userId, string title, string content) 
        {
            UserId = userId;
            Title = title;
            Content = content;
        }
    }
}
