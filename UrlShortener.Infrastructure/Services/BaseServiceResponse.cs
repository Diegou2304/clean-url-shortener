

namespace UrlShortener.Infrastructure.Services
{
    public abstract class BaseServiceResponse
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
}
