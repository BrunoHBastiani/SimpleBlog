using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.DTOs.Posts.Responses
{
    public class GetPostByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public GetPostByIdResponse(Post post)
        {
            Id = post.Id;
            UserId = post.UserId;
            Title = post.Title;
            Content = post.Content;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;
        }
    }
}
