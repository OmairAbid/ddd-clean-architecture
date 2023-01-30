namespace Application.Commands.Contracts.Repositories;

public interface ISystemSettingCommandRepository : IAsyncCommandRepository<SystemSetting>
{
    Task<List<OldSystemSetting>> UpdateSystemSettingAsync(List<SystemSetting> systemSetting, CancellationToken cancellationToken = default);

    Task<List<SystemSetting>> GetByAttributeByNameAsync(List<string> attributeNames, CancellationToken cancellationToken = default);
}