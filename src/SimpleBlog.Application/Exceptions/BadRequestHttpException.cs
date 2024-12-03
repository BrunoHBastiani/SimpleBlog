using System.Net;

namespace SimpleBlog.Application.Exceptions
{
    public class BadRequestHttpException : HttpException
    {
        public BadRequestHttpException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
