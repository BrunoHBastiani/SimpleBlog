using SimpleBlog.Application.DTOs.Users.Requests;
using SimpleBlog.Application.DTOs.Users.Responses;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(CreateUserRequest createUserRequest);
        public Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest authenticateRequest);
        public Task<User> GetByIdAsync(Guid id);
    }
}
