using FluentValidation;


namespace UrlShortener.Application.Url.ShortUrl
{
    public class ShortUrlValidator : AbstractValidator<ShortUrlCommand>
    {
        public ShortUrlValidator() 
        {

            RuleFor(x => x.Url.targetUrl)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Requester.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Requester.Email)
                .EmailAddress()
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.UrlShortererProvider)
                .NotEmpty();
            
        }
    }
}
