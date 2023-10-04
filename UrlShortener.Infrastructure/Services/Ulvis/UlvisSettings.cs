

namespace UrlShortener.Infrastructure.Services.Ulvis
{
    public class UlvisSettings
    {
        public string Url;
    }

    public class UlvisServiceResponse
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string url { get; set; }
        public string full { get; set; }
    }
}
