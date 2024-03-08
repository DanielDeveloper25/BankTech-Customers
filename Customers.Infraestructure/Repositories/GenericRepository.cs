using Customers.Domain.Entities.Base;
using Customers.Domain.Interfaces;
using Customers.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infraestructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBase
    {
        private readonly CustomerDbContext _dbContext;

        public GenericRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task SoftDeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTimeOffset.UtcNow;
                entity.DeletedBy = "Anonymous";

                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().Where(x => !x.IsDeleted).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<TEntity>().Where(x => !x.IsDeleted);

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Set<TEntity>()
                .Where(x => !x.IsDeleted)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
