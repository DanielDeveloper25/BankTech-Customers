using Customers.Domain.Entities.Base;

namespace Customers.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBase
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task SoftDeleteAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties);
        Task<TEntity> GetByIdAsync(int id);
    }
}
