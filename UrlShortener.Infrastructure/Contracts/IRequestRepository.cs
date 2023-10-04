using UrlShortener.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain;

namespace UrlShortener.Application.Contracts
{
    public interface IRequestRepository : IGenericRepository<Requests>
    {
        public Task<Requests> GetRequestsByRequesterName(string requesterName);
        public Task<Requester> GetRequesterByEmail(string email);

    }
}
