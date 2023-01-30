
namespace Application.Commands.Contracts.Repositories
{
    public interface IAsyncCommandRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
