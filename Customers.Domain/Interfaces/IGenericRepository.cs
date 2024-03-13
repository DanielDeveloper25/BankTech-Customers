using Customers.Domain.Entities.Base;

namespace Customers.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBase
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task SoftDeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllWithPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdWithIncludeAsync(int id, List<string> properties, CancellationToken cancellationToken = default);
    }
}
