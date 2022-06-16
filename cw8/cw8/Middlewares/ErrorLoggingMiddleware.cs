using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace cw8.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                using var stream = new StreamWriter("logs.txt", true);
                await stream.WriteAsync($"{context.TraceIdentifier}, {ex.HResult}");
                await _next(context);
            }

            
        }
    }
}
