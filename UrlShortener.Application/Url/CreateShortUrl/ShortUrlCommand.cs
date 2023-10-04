using MediatR;
using UrlShortener.Application.Url.CreateShortUrl;

namespace UrlShortener.Application.Url.ShortUrl
{
    public class ShortUrlCommand : IRequest<CreateShortUrlResult>
    {
      
        public UrlCommand Url { get; set; }
        public RequesterCommand Requester { get; set; }
        public string UrlShortererProvider { get; set; }
        
    }

    public class UrlCommand
    {
       
        public string targetUrl { get; set; } 

    }

    public class RequesterCommand
    {
      
        public string Name { get; set; }
        public string? Email { get; set; }
   
    }
}
