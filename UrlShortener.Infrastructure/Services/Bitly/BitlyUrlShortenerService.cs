using Newtonsoft.Json;
using System.Text;
using UrlShortener.Application.Url.Utils.UrlShortener;

namespace UrlShortener.Infrastructure.Services.Bitly
{
    public class BitlyUrlShortenerService : IUrlShortenerService  
    {
        private readonly IHttpClientFactory _httpClientFactory;
     
        public BitlyUrlShortenerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       

        public async Task<string> GenerateShortedUrlAsync(string url)
        {

            var bitlySettings = new BitlySettings
            {
                long_url = url,
                domain = "bit.ly"
            };
            var json = JsonConvert.SerializeObject(bitlySettings);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = _httpClientFactory.CreateClient("BitlyClient");
            var shortenedUrl = await httpClient
                .PostAsync("/v4/shorten", data);

            var responseStringContent = shortenedUrl.Content.ReadAsStringAsync().Result;

            BitlyUrlData response = JsonConvert.DeserializeObject<BitlyUrlData>(responseStringContent);

            return response.Id;
        }
    }
}
