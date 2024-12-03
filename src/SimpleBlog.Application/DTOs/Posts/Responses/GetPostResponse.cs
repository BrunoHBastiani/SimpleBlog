using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.DTOs.Posts.Responses
{
    public record GetPostResponse
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        public GetPostResponse(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
            UserId = post.UserId;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;
        }
    }
}
