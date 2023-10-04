using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Url.CreateShortUrl;
using UrlShortener.Application.Url.ShortUrl;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RequestsController(IMediator mediator) 
        {
            _mediator = mediator;

        }

        [HttpPost]
        [Route("url")]
        public  async Task<ActionResult<CreateShortUrlResult>> ShortUrl([FromBody] ShortUrlCommand shortUrl)
        {
            return await _mediator.Send(shortUrl);
        }

    }
}
