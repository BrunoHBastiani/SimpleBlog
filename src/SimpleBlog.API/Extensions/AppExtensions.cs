using SimpleBlog.API.Authentication;
using SimpleBlog.API.Notification;

namespace SimpleBlog.API.Extensions
{
    public static class AppExtensions
    {
        public static void UseArchitectures(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleBlog API v1");
            });

            app.MapHub<NotificationHub>("/postNotificationHub");

            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
