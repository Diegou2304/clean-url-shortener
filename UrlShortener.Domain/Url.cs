

namespace UrlShortener.Domain
{
    public sealed class Url
    {
        public int UrlId { get; set;}
        public string targetUrl { get; set; } = string.Empty; 
        public string ShortenedUrl { get; set; } = string.Empty;
        public List<Requester> Requesters { get; } = new();
        public List<Requests> Requests { get; } = new();

    }
}
