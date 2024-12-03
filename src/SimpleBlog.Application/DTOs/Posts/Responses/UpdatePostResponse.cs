using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.DTOs.Posts.Responses
{
    public record UpdatePostResponse
    {
        public Guid UserId { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        public UpdatePostResponse(Post post)
        {
            UserId = post.UserId;
            Title = post.Title;
            Content = post.Content;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;
        }
    }
}
