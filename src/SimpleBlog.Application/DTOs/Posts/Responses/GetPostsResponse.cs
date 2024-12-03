using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.DTOs.Posts.Responses
{
    public record GetPostsResponse
    {
        public List<GetPostResponse> Posts { get; set; }

        public GetPostsResponse(IEnumerable<Post> posts)
        {
            Posts = posts.Select(post => new GetPostResponse(post)).ToList();
        }
    }
}
