using Azure;
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
        public async Task<BaseServiceResponse> GenerateShortedUrlAsync(string url)
        {

            var ulvisSettings = new UlvisSettings
            {
                Url = url,
            };

            var _httpClient = _httpClientFactory.CreateClient("UlvisClient");
            var shortenedUrl = await _httpClient
                                    .GetAsync($"/API/write/get?url={ulvisSettings.Url}");
            var result = shortenedUrl.Content.ReadAsStringAsync().Result;
            UlvisServiceResponse response = JsonConvert
                .DeserializeObject<UlvisServiceResponse>(result);




            return MapToBaseServiceResponse(response);
        }

        private BaseServiceResponse MapToBaseServiceResponse(UlvisServiceResponse ulvisResponse)
        {
            if (ulvisResponse.success)
            {
                return new SuccessfulResponse
                {
                    StatusCode = 200,
                    LongUrl = ulvisResponse.data.full,
                    ShortUrl = ulvisResponse.data.url
                };
            }

            return new ErrorResponse
            {
                StatusCode = 400,
                ErrorCode = ulvisResponse.error.code,
                Message = ulvisResponse.error.msg
            };
        }
    }
}
