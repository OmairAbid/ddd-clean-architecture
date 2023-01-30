namespace Application.Commands.Contracts.Repositories.Commands;

public interface IAdministratorLogRepository : IAsyncCommandRepository<AdministratorLog>
{
    Task<bool> AddAdministratorLogAsync(AdministratorLog administratorLog);

    Task<AdministratorLog?> GetByAction(string action);
}