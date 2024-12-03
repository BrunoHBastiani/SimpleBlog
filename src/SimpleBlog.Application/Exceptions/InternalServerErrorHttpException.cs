using System.Net;

namespace SimpleBlog.Application.Exceptions
{
    public class InternalServerErrorHttpException : HttpException
    {
        public InternalServerErrorHttpException(string message) : base(HttpStatusCode.InternalServerError, message) { }
    }
}
