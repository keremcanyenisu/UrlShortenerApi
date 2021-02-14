using Microsoft.EntityFrameworkCore;
using UrlShortenerApi.Entities;

namespace UrlShortenerApi.Context
{
    public class UrlShortenerContext : DbContext
    {
        public DbSet<UrlInfo> UrlInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=urlshortener.db");
    }
}
