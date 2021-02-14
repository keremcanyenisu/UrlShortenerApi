using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortenerApi.Models;
using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : Controller
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlShortenerController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
           
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateShortenedUrl([FromBody] CreateShortenedUrlRequest request)
        {
                var siteUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                var shortenedKey = await _urlShortenerService.CreateShortenedUrl(request.OriginalUrl);
                var shortenedUrl = string.Concat(siteUrl, "/", shortenedKey);
                return new JsonResult(new CreateShortenedUrlResponse { ShortenedUrl = shortenedUrl });

        }
    }
}
