using System.ComponentModel.DataAnnotations;

namespace UrlShortenerApi.Entities
{
    public class UrlInfo
    {
        [Key]
        public long Id { get; set; }

        public string Original { get; set; }

        public string Shortened { get; set; }
    }
}
