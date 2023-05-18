using Login.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Login
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Handhing
    {
        private readonly RequestDelegate _next;
        ILogger<Handhing> _logger;

        public Handhing(RequestDelegate next, ILogger<Handhing> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError($"Server error: {e.Message}, {e.StackTrace}");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Internal server error");
            }
        }
     }

        // Extension method used to add the middleware to the HTTP request pipeline.
        public static class HandhingExtensions
{
    public static IApplicationBuilder UseHandhing(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Handhing>();
    }
}
    
}
