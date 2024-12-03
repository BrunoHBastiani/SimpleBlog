using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.API.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static User GetLoggedUser(this ControllerBase controller)
        {
            var user = controller.HttpContext.Items["User"];
            if (user != null) return (User)user;

            throw new Exception("Usuário não logado");
        }
    }
}
