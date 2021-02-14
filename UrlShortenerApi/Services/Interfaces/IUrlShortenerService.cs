
using System.Threading.Tasks;

namespace UrlShortenerApi.Services.Interfaces
{
    public interface IUrlShortenerService
    {
        Task<string> CreateShortenedUrl(string originalUrl);
        Task<string> GetOriginalUrl(string shortUrlKey);
    }
}
