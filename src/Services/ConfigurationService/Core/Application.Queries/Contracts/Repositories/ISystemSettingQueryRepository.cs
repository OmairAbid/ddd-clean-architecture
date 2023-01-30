

namespace Application.Queries.Contracts.Repositories;
using SystemSetting = Domain.QueryEntities.SystemSetting;
public interface ISystemSettingQueryRepository
{
    Task<SystemSetting> GetByAttributeNameAsync(string parms, CancellationToken cancellationToken = default);

    Task<IList<SystemSetting>> GetAllAsync(CancellationToken cancellationToken = default);
}
