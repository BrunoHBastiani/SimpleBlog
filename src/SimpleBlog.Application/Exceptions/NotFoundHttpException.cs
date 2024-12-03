using System.Net;

namespace SimpleBlog.Application.Exceptions
{
    public class NotFoundHttpException : HttpException
    {
        public NotFoundHttpException(string message) : base(HttpStatusCode.NotFound, message) { }
    }
}
