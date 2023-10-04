using UrlShortener.Domain.Common;

namespace UrlShortener.Application.Contracts
{
    public interface IGenericRepository<T>  where T : AuditModel
    {
       
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetByCreatedByAsync(string creator);
        Task<IEnumerable<T>> GetAll();



    }
}
