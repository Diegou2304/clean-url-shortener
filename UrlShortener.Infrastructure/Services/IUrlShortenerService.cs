using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Application.Url.Utils.UrlShortener
{
    public interface IUrlShortenerService
    {
        public Task<string> GenerateShortedUrlAsync(string url);
    }
}
