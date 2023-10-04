﻿
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UrlShortener.Infrastructure.Services.Bitly
{
    public class BitlySettings
    {
        public string long_url { get; set; } = string.Empty;
        public string domain { get; set; } = string.Empty;
    }

    public class BitlyUrlData : BaseServiceResponse
    {
        public DateTime CreatedAt { get; set; }
        public string Id { get; set; }
        public string link { get; set; }
        public string long_url { get; set; }
        public bool Archived { get; set; }
       

    }
    public class References
    {
        public string Group { get; set; }
    }
}
