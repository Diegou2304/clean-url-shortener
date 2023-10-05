using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Application.Url.Utils.UrlShortener
{
    public interface IUrlShortenerService
    {
        public Task<BaseServiceResponse> GenerateShortedUrlAsync(string url);
    }
}
