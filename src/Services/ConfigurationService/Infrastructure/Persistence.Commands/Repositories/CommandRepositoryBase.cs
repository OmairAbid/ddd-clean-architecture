

using Microsoft.EntityFrameworkCore;

namespace Persistence.Commands.Repositories
{
    public class CommandRepositoryBase<T> : IAsyncCommandRepository<T> where T : EntityBase
    {
        protected readonly AppDBContext _dbContext;

        public CommandRepositoryBase(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            await Task.FromResult( _dbContext.Set<T>().Remove(entity));
            
        }

        public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken)
        {
            T entity = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            _dbContext.Set<T>().Remove(entity);
            //int value = await _dbContext.SaveChangesAsync(cancellationToken);
            //return  value > 0 ? true : false;
        }
    }
}
