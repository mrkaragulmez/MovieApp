using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MovieApp.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "x-api-key";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        } 
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out
                    var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            List<string> apiKey = appSettings.GetSection("ApiKeys").Get<List<string>>()?.ToList();
            if (!apiKey.Any(x => x == extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}
