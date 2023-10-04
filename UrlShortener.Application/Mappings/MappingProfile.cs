using AutoMapper;
using UrlShortener.Application.Url.ShortUrl;
using UrlShortener.Domain;

namespace UrlShortener.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UrlCommand, Domain.Url>();
            CreateMap<RequesterCommand, Requester>();
          
        }
     
    }
}
