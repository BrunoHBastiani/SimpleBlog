using SimpleBlog.Application.DTOs.Posts.Requests;
using SimpleBlog.Application.DTOs.Posts.Responses;

namespace SimpleBlog.Application.Interfaces
{
    public interface IPostService
    {
        Task<Guid> CreateAsync(CreatePostRequest createPostRequest, Guid userId);
        Task<UpdatePostResponse> UpdateAsync(UpdatePostRequest request, Guid postId, Guid userId);
        Task<GetPostByIdResponse> GetByIdAsync(Guid postId);
        Task<GetPostsResponse> GetAsync(GetPostsRequest getPostsRequest);
        Task DeleteAsync(Guid postId, Guid userId);
    }
}
