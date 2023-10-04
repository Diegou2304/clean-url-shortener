using UrlShortener.Infrastructure.Services.Bitly;
using UrlShortener.Infrastructure.Services.Ulvis;

namespace UrlShortener.Application.Url.Utils.UrlShortener
{
    public class UrlShortenerServiceFactory : IUrlShortenerServiceFactory
    {
        private readonly IEnumerable<IUrlShortenerService> _urlShortenerServices;

        public UrlShortenerServiceFactory(IEnumerable<IUrlShortenerService> urlShortenerServices)
        {
            _urlShortenerServices = urlShortenerServices;
        }
        public IUrlShortenerService GetInstance(string token)
        {
            return token switch
            {
                "bitly" => GetService(typeof(BitlyUrlShortenerService)),
                "ulvis" => GetService(typeof(UlvisShortenerService)),
                _ => GetService(typeof(BitlyUrlShortenerService))

            };
        }

        private IUrlShortenerService GetService(Type type)
        {
            return _urlShortenerServices.FirstOrDefault(x => x.GetType() == type);
        }
    }
}
