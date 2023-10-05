

using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Application.Url.CreateShortUrl
{
    public  class CreateShortUrlResult
    {
       

    }

    public class CreateShortUrlErrorResult : CreateShortUrlResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }

    }

    public class CreateShortUrlSucessfullResult : CreateShortUrlResult
    {
        public int StatusCode { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
