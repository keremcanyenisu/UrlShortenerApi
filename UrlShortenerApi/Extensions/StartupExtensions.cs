
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UrlShortenerApi.Middlewares;
using UrlShortenerApi.Services;
using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Extensions
{
    public static class StartupExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUrlShortenerService,UrlShortenerService>();
        }

        public static void UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<RedirectionMiddleware>();
        }
    }
}
