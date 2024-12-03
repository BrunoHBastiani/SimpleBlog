using SimpleBlog.Application.DTOs.Posts.Requests;
using SimpleBlog.Application.DTOs.Posts.Responses;
using SimpleBlog.Application.Exceptions;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Data.Filters;
using SimpleBlog.Data.Interfaces;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly INotificationService _notificationService;

        public PostService(IPostRepository postRepository, INotificationService notificationService)
        {
            _postRepository = postRepository;
            _notificationService = notificationService;
        }

        public async Task<Guid> CreateAsync(CreatePostRequest createPostRequest, Guid userId)
        {
            Post newPost = new Post(
                userId,
                createPostRequest.Title,
                createPostRequest.Content
            );

            Guid? createdPostId = await _postRepository.CreateAsync(newPost);
            if (createdPostId == null) throw new InternalServerErrorHttpException("Ocorreu um erro ao tentar criar a postagem. Tente novamente em alguns minutos.");

            await _notificationService.SendNotificationAsync(newPost.Title);

            return createdPostId.Value;
        }

        public async Task<UpdatePostResponse> UpdateAsync(UpdatePostRequest request, Guid postId, Guid userId)
        {
            Post existingPost = await _postRepository.GetByIdAsync(postId);
            if (existingPost == null) throw new NotFoundHttpException("Postagem não encontrada!");
            if (existingPost.UserId != userId) throw new ForbiddenHttpException("Você não tem permissão para editar essa postagem!");

            if (!string.IsNullOrEmpty(request.Title)) existingPost.Title = request.Title;
            if (!string.IsNullOrEmpty(request.Content)) existingPost.Content = request.Content;

            Post updatedPost = await _postRepository.UpdateAsync(existingPost);
            if (updatedPost == null) throw new InternalServerErrorHttpException("Ocorreu um erro ao tentar atualizar a postagem. Tente novamente em alguns minutos.");

            return new UpdatePostResponse(updatedPost);
        }

        public async Task<GetPostByIdResponse> GetByIdAsync(Guid postId)
        {
            Post existingPost = await _postRepository.GetByIdAsync(postId);
            if (existingPost == null) throw new NotFoundHttpException("Postagem não encontrada!");

            return new GetPostByIdResponse(existingPost);
        }

        public async Task<GetPostsResponse> GetAsync(GetPostsRequest getPostsRequest)
        {
            PostFilter postFilter = new PostFilter(
                getPostsRequest.UserId,
                getPostsRequest.Title,
                getPostsRequest.Content
            );

            IEnumerable<Post> posts = await _postRepository.GetAsync(postFilter);
            return new GetPostsResponse(posts);
        }

        public async Task DeleteAsync(Guid postId, Guid userId)
        {
            Post existingPost = await _postRepository.GetByIdAsync(postId);
            if (existingPost == null) throw new NotFoundHttpException("Postagem não encontrada!");
            if (existingPost.UserId != userId) throw new ForbiddenHttpException("Você não tem permissão para deletar essa postagem!");

            await _postRepository.DeleteAsync(existingPost);
        }
    }
}
