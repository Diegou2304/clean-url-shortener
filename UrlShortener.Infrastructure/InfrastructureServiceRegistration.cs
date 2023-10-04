using UrlShortener.Application.Contracts;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using UrlShortener.Application.Url.Utils.UrlShortener;
using UrlShortener.Infrastructure.Services.Bitly;

namespace UrlShortener.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        private const string Bitly = "ShortenerServices:Bitly";

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRequestRepository, RequestsRepository>();
            services.AddDbContext<UrlShortenerDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddHttpClient<IUrlShortenerService, BitlyUrlShortenerService>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(configuration.GetSection(Bitly + ":BaseUrl").Value);
                client.DefaultRequestHeaders.Add("Authorization","Bearer " + configuration.GetSection(Bitly + ":AccessToken").Value);
            });
            return services;
        }
    }
}
