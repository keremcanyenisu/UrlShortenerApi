
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Middlewares
{
    public class RedirectionMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                var path = context.Request.Path.Value;

                if (path != "/")
                {
                    var shortenedKey = path.Remove(0, 1);
                    var urlShortenedService = context.RequestServices.GetService<IUrlShortenerService>();

                    var originalUrl = await urlShortenedService.GetOriginalUrl(shortenedKey);

                    if (!string.IsNullOrEmpty(originalUrl))
                    {
                        context.Response.Redirect(originalUrl);
                        return;
                    }

                }


                await _next(context);
            }
            catch (System.Exception ex)
            {
                await context.Response.WriteAsync("System Error = " + ex.Message);
                return;
            }
        }
    }
}
