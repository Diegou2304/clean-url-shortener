using UrlShortener.Application.Contracts;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using UrlShortener.Application.Contracts;
using UrlShortener.Domain;

namespace UrlShortener.Infrastructure.Repositories
{
    public class RequestsRepository : GenericRepository<Requests>, IRequestRepository
    {
        private readonly UrlShortenerDbContext _context;
        public RequestsRepository(UrlShortenerDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Requests>GetRequestsByRequesterName(string requesterName)
        {
            return await _context.requests
                .FirstOrDefaultAsync(r => r.Requester.Name == requesterName);
        }

        public async Task<Requester> GetRequesterByEmail(string email)
        {
            var requester = await _context.requester.FirstOrDefaultAsync(x =>x.Email == email);

            return requester;
        }

        

    }
}
