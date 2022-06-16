using cw8.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace cw8.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}
