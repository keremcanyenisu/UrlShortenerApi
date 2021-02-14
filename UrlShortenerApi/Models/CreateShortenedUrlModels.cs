using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerApi.Models
{
    public class CreateShortenedUrlRequest
    {
        public string OriginalUrl { get; set; }
    }

    public class CreateShortenedUrlResponse
    {
        public string ShortenedUrl { get; set; }

        public string Error { get; set; }
    }
}
