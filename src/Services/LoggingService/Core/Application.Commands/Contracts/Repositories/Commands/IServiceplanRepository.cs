namespace Application.Commands.Contracts.Repositories.Commands
{
    public interface IServiceplanRepository
    {
        public Task<Serviceplan> GetByIdAsync(int id);
    }
}