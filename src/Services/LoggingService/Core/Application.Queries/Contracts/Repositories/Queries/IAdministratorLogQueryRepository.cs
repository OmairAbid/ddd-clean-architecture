using Application.Queries.Features;

namespace Application.Queries.Contracts.Repositories.Queries;

public interface IAdministratorLogQueryRepository
{
    Task<AdministratorQueryResponse> GetAsync(string parms);

    Task<IList<AdministratorQueryResponse>> GetAllAsync();

    Task<Tuple<IList<AdministratorQueryResponse>, int>> GetAsync(GetAdministratorLogsRequest request);
}