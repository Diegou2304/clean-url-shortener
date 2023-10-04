using UrlShortener.Application.Contracts;
using UrlShortener.Domain.Common;
using UrlShortener.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : AuditModel
    {
        private readonly UrlShortenerDbContext _context;

        public GenericRepository(UrlShortenerDbContext context)
        {
            _context = context;
            
        }
        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<T>> GetByCreatedByAsync(string creator)
        {
            return await _context.Set<T>().Where(d => d.CreatedBy == creator).ToListAsync();
        }

     

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
