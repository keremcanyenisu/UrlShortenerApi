using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Controllers
{

    [ApiController]
    public class HomeController : Controller
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public HomeController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(new JsonResult("Api is running"));
        }
    }

}
