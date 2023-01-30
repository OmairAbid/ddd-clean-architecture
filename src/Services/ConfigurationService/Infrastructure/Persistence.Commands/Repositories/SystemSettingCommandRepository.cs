using AngleSharp.Dom;
using Application.Commands.Common.Models;
using Application.Commands.Contracts.Common;

namespace Persistence.Commands.Repositories;

public class SystemSettingCommandRepository : CommandRepositoryBase<SystemSetting>, ISystemSettingCommandRepository
{
    private readonly IUnitOfWork _unitOfWork;
    public SystemSettingCommandRepository(AppDBContext dbContext,
        IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<OldSystemSetting>> UpdateSystemSettingAsync(List<SystemSetting> systemSetting, CancellationToken cancellationToken)
    {
        var settings = await _dbContext.SystemSetting.Where(x => (systemSetting.Select(s => s.AttributeName).ToList()).Contains(x.AttributeName)).ToListAsync();
        List<OldSystemSetting> oldSystemSetting = new();
        if (settings != null && settings.Count() > 0)
        {


            int count = 0;
            settings.ForEach((prop) =>
            {
                oldSystemSetting.Add(new OldSystemSetting { AttributeName = prop.AttributeName, AttributeValue = prop.AttributeValue });
                prop.AttributeValue = systemSetting[count].AttributeValue;
                prop.AttributeDefaultValue = systemSetting[count].AttributeDefaultValue;
                prop.SortOrder = systemSetting[count].SortOrder;
                prop.GroupName = systemSetting[count].GroupName;
                prop.FieldType = systemSetting[count].FieldType;
                prop.CreatedBy = prop.CreatedBy;
                prop.CreatedOn = prop.CreatedOn;

                count++;
            });



            _dbContext.UpdateRange(settings);
            return oldSystemSetting;

        }
        return oldSystemSetting;
    }

    public async Task<List<SystemSetting>> GetByAttributeByNameAsync(List<string> attributeNames, CancellationToken cancellationToken)
    {
        return await _dbContext.SystemSetting.Where(x => attributeNames.Contains(x.AttributeName)).AsNoTracking().ToListAsync();
    }
}