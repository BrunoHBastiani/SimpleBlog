
using System.Net;

namespace SimpleBlog.Application.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; }
        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = (int)statusCode;
        }
    }
}
