using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Authentication
{
    public interface IJwtService
    {
        public string GenerateJwtToken(User user);
        public string? ValidateJwtToken(string? token);
    }
}
