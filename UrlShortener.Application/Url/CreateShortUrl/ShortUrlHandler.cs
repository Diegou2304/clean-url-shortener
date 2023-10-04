using AutoMapper;
using MediatR;
using UrlShortener.Application.Contracts;
using UrlShortener.Application.Url.CreateShortUrl;
using UrlShortener.Application.Url.Utils.UrlShortener;
using UrlShortener.Domain;
using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Application.Url.ShortUrl
{
    public class ShortUrlHandler : IRequestHandler<ShortUrlCommand, CreateShortUrlResult>
    {

        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        private readonly IUrlShortenerServiceFactory _urlShortenerServiceFactory;
        public ShortUrlHandler(IRequestRepository requestRepository,
                                IMapper mapper,
                                IUrlShortenerServiceFactory urlShortenerServiceFactory)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _urlShortenerServiceFactory = urlShortenerServiceFactory;
        }
        public async Task<CreateShortUrlResult> Handle(ShortUrlCommand request, CancellationToken cancellationToken)
        {

          
            var url = _mapper.Map<UrlCommand>(request.Url);
            var requesterCommand = _mapper.Map<RequesterCommand>(request.Requester); 
            var registeredRequester = await _requestRepository.GetRequesterByEmail(requesterCommand.Email) ?? new Requester(requesterCommand.Name, requesterCommand.Email);

            IUrlShortenerService urlShortenerProvider =  GetUrlShortenerProvider(request.UrlShortererProvider);

            string shorterUrl = await urlShortenerProvider.GenerateShortedUrlAsync(url.targetUrl);


            var targetUrl = new Domain.Url
            {
                targetUrl = url.targetUrl,
                ShortenedUrl = shorterUrl
            };

            var urlRequest = new Requests
            {

                Url = targetUrl,
                Requester = registeredRequester
            };

            urlRequest.SetGuid();

            await _requestRepository.AddAsync(urlRequest);


            return new CreateShortUrlResult
            {
                Url = shorterUrl

            };

        }

        private IUrlShortenerService GetUrlShortenerProvider(string provider)
        {
            return _urlShortenerServiceFactory.GetInstance(provider);
        }
    }
}
