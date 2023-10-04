

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace UrlShortener.Application.Url.Utils.UrlShortener
{
    public class LocalUrlShortener : IUrlShortener
    {
        private readonly IConfiguration _configuration;
        public LocalUrlShortener(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateShortedUrl(string url)
        {
            var baseUrl = _configuration.GetValue<string>("BaseShortenerUrl:Url");

            if (url is null) return "";

            return baseUrl + Guid.NewGuid().ToString();

        }

    }
}
