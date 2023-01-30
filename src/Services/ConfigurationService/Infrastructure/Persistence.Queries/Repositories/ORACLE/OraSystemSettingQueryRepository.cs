using Application.Queries.Common.Models;
using Application.Queries.Contracts.Common;
using SystemSetting = Domain.QueryEntities.SystemSetting;
namespace Persistence.Queries.Repositories.ORACLE;

public class OraSystemSettingQueryRepository : ISystemSettingQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public OraSystemSettingQueryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SystemSetting> GetByAttributeNameAsync(string attributeName, CancellationToken cancellationToken = default)
    {
        var query = @"select Id, AttributeName, AttributeValue, AttributeDefaultValue, FieldType, GroupName, SortOrder from SystemSetting where AttributeName= @AttributeName";

        return await _unitOfWork.Connection.QuerySingleAsync<SystemSetting>(query, new { AttributeName = attributeName });
    }

    public async Task<IList<SystemSetting>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var query = @"SELECT Id, AttributeName, AttributeValue, AttributeDefaultValue, FieldType, GroupName, SortOrder FROM SystemSetting";

        var response = await _unitOfWork.Connection.QueryAsync<SystemSetting>(query);
        return response.ToList();
    }
}