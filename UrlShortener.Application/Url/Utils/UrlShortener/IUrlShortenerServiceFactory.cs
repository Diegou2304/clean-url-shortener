
namespace UrlShortener.Application.Url.Utils.UrlShortener
{
    public interface IUrlShortenerServiceFactory
    {
        IUrlShortenerService GetInstance(string token);

    }
}
