using SimpleBlog.Application.Authentication;
using SimpleBlog.Application.Interfaces;

namespace SimpleBlog.API.Authentication
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtService jwtUtils)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            string userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null) context.Items["User"] = await userService.GetByIdAsync(Guid.Parse(userId));

            await _next(context);
        }
    }
}
