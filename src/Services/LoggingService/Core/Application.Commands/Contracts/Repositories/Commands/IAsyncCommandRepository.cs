namespace Application.Commands.Contracts.Repositories.Commands
{
    public interface IAsyncCommandRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> DeleteByIdAsync(Guid id);
    }
}