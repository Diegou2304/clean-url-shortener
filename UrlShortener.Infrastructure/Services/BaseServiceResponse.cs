

namespace UrlShortener.Infrastructure.Services
{
    public abstract class BaseServiceResponse
    {
        public int StatusCode { get; set; }
     
    }

    public class ErrorResponse : BaseServiceResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; } 

    }

    public class SuccessfulResponse : BaseServiceResponse
    {
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }

    }
}
