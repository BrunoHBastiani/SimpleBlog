using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.DTOs.Users.Responses
{
    public record AuthenticateResponse
    {
        public User User { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
