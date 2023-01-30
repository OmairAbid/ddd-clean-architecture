using Application.Queries.Contracts.Common;
using SystemSetting = Domain.QueryEntities.SystemSetting;
namespace Persistence.Queries.Repositories.SQL;

public class SystemSettingQueryRepository : ISystemSettingQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public SystemSettingQueryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SystemSetting> GetByAttributeNameAsync(string attributeName, CancellationToken cancellationToken = default)
    {
        var query = @"SELECT Id, AttributeName, AttributeValue, AttributeDefaultValue, FieldType, GroupName, SortOrder FROM SystemSetting WHERE AttributeName= @AttributeName";
        return await _unitOfWork.Connection.QuerySingleAsync<SystemSetting>(query, new { AttributeName = attributeName });
    }

    public async Task<IList<SystemSetting>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var query = @"SELECT Id, AttributeName, AttributeValue, AttributeDefaultValue, FieldType, GroupName, SortOrder  FROM SystemSetting";

        var response = await _unitOfWork.Connection.QueryAsync<SystemSetting>(query);
        return response.ToList();
    }
}