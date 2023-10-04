
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UrlShortener.Application.Contracts;
using UrlShortener.Application.Url.Utils.UrlShortener;
using UrlShortener.Infrastructure.Repositories;
using UrlShortener.Infrastructure.Services.Bitly;
using UrlShortener.Infrastructure.Services.Ulvis;

namespace UrlShortener.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IUrlShortener, LocalUrlShortener>();
            services.AddScoped<IUrlShortenerService, BitlyUrlShortenerService>();
            services.AddScoped<IUrlShortenerService, UlvisShortenerService>();
            services.AddScoped<IUrlShortenerServiceFactory, UrlShortenerServiceFactory>();
            return services;
        }
       
    }
}
