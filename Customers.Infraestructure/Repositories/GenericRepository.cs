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

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task SoftDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTimeOffset.UtcNow;
                entity.DeletedBy = "Anonymous";
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<TEntity>().Where(x => !x.IsDeleted);
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>()
                                   .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllWithPaginationAsync(int pageNumber, int pageSize, List<string>? includeProperties = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>()
                                                  .Where(x => !x.IsDeleted)
                                                  .Skip((pageNumber - 1) * pageSize)
                                                  .Take(pageSize);

            if (includeProperties != null)
            {
                foreach (string property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return await query.ToListAsync(cancellationToken);
        }


        public virtual async Task<TEntity> GetByIdWithIncludeAsync(int id, List<string> properties, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<TEntity>()
                .Where(x => x.Id == id && !x.IsDeleted);

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
