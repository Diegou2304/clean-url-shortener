using Newtonsoft.Json;
using UrlShortener.Application.Url.Utils.UrlShortener;


namespace UrlShortener.Infrastructure.Services.Ulvis
{
    public class UlvisShortenerService : IUrlShortenerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
       

        public UlvisShortenerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
       


        }
        public async Task<string> GenerateShortedUrlAsync(string url)
        {

            var ulvisSettings = new UlvisSettings
            {
                Url = url,
            };

            var _httpClient = _httpClientFactory.CreateClient("UlvisClient");
            var shortenedUrl = await _httpClient
                                    .GetStringAsync($"/API/write/get?url={ulvisSettings.Url}");

            UlvisServiceResponse response = JsonConvert.DeserializeObject<UlvisServiceResponse>(shortenedUrl);



            return response.data.url;
        }
    }
}
