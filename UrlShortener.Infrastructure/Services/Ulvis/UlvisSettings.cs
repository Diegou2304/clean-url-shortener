

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
        public Error? error { get; set; } 
    }

    public class Data
    {
        public string id { get; set; }
        public string url { get; set; }
        public string full { get; set; }
    }
    public class Error
    {
        public int code { get; set; } 
        public string msg { get; set; } = string.Empty;
    }
}
