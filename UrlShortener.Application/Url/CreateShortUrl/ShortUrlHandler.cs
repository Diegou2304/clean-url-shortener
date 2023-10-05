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
            var registeredRequester = await _requestRepository.GetRequesterByEmail(requesterCommand.Email) 
                                                                ?? new Requester(requesterCommand.Name, requesterCommand.Email);

            IUrlShortenerService urlShortenerProvider =  GetUrlShortenerProvider(request.UrlShortererProvider);

            var shorterUrl = await urlShortenerProvider.GenerateShortedUrlAsync(url.targetUrl);

            if (shorterUrl.StatusCode is 200 || shorterUrl.StatusCode is 201)
            {
              

                var targetUrl = Domain.Url.Create(url.targetUrl, (shorterUrl as SuccessfulResponse)?.ShortUrl);
                var newRequest = Requests.Create(targetUrl, registeredRequester);


                newRequest.SetGuid();

                await _requestRepository.AddAsync(newRequest);

                return new CreateShortUrlSucessfullResult
                {
                    StatusCode = shorterUrl.StatusCode,
                    LongUrl = (shorterUrl as SuccessfulResponse)?.LongUrl,
                    ShortUrl = (shorterUrl as SuccessfulResponse)?.ShortUrl
                };

            }
            else
            {
                return new CreateShortUrlErrorResult
                {
                    StatusCode = shorterUrl.StatusCode,
                    ErrorCode = (int)((shorterUrl as ErrorResponse)?.ErrorCode),
                    Message = (shorterUrl as ErrorResponse)?.Message
                };
            }
           

        }

        private IUrlShortenerService GetUrlShortenerProvider(string provider)
        {
            return _urlShortenerServiceFactory.GetInstance(provider);
        }
    }
}
