using System.Net;

namespace SimpleBlog.Application.Exceptions
{
    public class ForbiddenHttpException : HttpException
    {
        public ForbiddenHttpException(string message) : base(HttpStatusCode.Forbidden, message) { }
    }
}
