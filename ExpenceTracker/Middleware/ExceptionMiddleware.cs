using System.Net;
using System.Text.Json;

namespace ExpenceTracker.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context,ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext,Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            HttpStatusCode statusCode = exception switch
            {
                KeyNotFoundException => HttpStatusCode.NotFound,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                ArgumentException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            httpContext.Response.StatusCode = (int)statusCode;

            var response = new
            {
                statusCode = (int)statusCode,
                Message = exception.Message,
            };

            var json = JsonSerializer.Serialize(response);
            return httpContext.Response.WriteAsync(json);
        }
    }
}
