
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerApi.Context;
using UrlShortenerApi.Entities;
using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly UrlShortenerContext _urlShortenerContext;

        public UrlShortenerService(UrlShortenerContext urlShortenerContext)
        {
            _urlShortenerContext = urlShortenerContext;
        }

        public async Task<string> CreateShortenedUrl(string originalUrl)
        {
            if(!originalUrl.StartsWith("http://") && !originalUrl.StartsWith("https://"))
            {
                originalUrl = "https://" + originalUrl;
            }

            var newUrlInfo = new UrlInfo
            {
                Original = originalUrl
            };

            _urlShortenerContext.UrlInfos.Add(newUrlInfo);
            await _urlShortenerContext.SaveChangesAsync();

            var key = GenerateShortenedUrlKey(newUrlInfo.Id);
            newUrlInfo.Shortened = key.ToLower();
            await _urlShortenerContext.SaveChangesAsync();

            return newUrlInfo.Shortened;
        }

        public async Task<string> GetOriginalUrl(string shortUrlKey)
        {
            var originalUrl = _urlShortenerContext.UrlInfos.FirstOrDefault(x => x.Shortened == shortUrlKey)?.Original;
            return await Task.FromResult(originalUrl);
        }

        private string GenerateShortenedUrlKey(long id)
        {
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
        }
    }
}
