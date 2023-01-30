using AngleSharp.Io;
using Application.Commands.Common.Enumerations;
using Application.Commands.Common.Mappings;
using EventBus;
using EventBus.Logging.Operator;
using EventBus.Models;

using MassTransit;

namespace Application.Commands.Features.Update;

public class UpdateSystemSettingRequest : IRequest<BasicResponse>
{
    #region Public Properties

    public List<SystemSetting> SystemSettings { get; set; }

    #endregion Public Properties
}

public class UpdateSystemSettingRequestHandler : IRequestHandler<UpdateSystemSettingRequest, BasicResponse>
{
    #region Private Fields

    private readonly IAuditLogHelper _audiLogger;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISystemSettingCommandRepository _systemSettingCommandRepository;

    #endregion Private Fields

    #region Public Constructors

    public UpdateSystemSettingRequestHandler(ISystemSettingCommandRepository systemSettingCommandRepository,
        //IPublishEndpoint publishEndpoint,
        IAuditLogHelper audiLogger,
        IUnitOfWork unitOfWork
        )
    {
        _systemSettingCommandRepository = systemSettingCommandRepository;
        //_publishEndpoint = publishEndpoint;
        _audiLogger = audiLogger;
        _unitOfWork = unitOfWork;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse> Handle(UpdateSystemSettingRequest request, CancellationToken cancellationToken)
    {
        //TODO : Add Role Check to make sure user has rights to update the GlobalSettings.

        List<OldSystemSetting> olderValues = new();

        olderValues = await _systemSettingCommandRepository.UpdateSystemSettingAsync(request.SystemSettings, cancellationToken);

        BasicResponse response = new();
        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            await PublishAdministratorLogs("admin@domain.com", olderValues, request.SystemSettings);

            response.Success = true;
        }

        return response;
    }

    #endregion Public Methods

    #region Private Methods

    private async Task PublishAdministratorLogs(string email, List<OldSystemSetting> olderValues, List<SystemSetting> newValues)
    {
        List<string> includedColumns = new List<string>() { "AttributeName", "AttributeValue" };
        olderValues = olderValues.OrderBy(o => o.AttributeName).ToList();
        newValues = newValues.OrderBy(o => o.AttributeName).ToList();

        IList<AuditDelta> changeList = await _audiLogger.CompareAsync(olderValues, newValues, includedColumns, AuditKeyMappings.SystemSettingAuditLogDictionary);
        _ = _publishEndpoint.Publish<IMessage<OperatorLogRequest>>(new
        {
            Id = Guid.NewGuid(),
            Type = typeof(List<SystemSetting>).Name,
            RouteKey = "operator",
            Data = new OperatorLogRequest(
                                         action: AdminLogAction.ADMIN_ACTIVITY_UPDATED.ToString(),
                                         module: AdminLogModule.ADMIN_ACTIVITY_MODULE_CONFIGURATIONS.ToString(),
                                         subModule: AdminLogModule.ADMIN_ACTIVITY_SUB_MODULE_OPERATOR.ToString(),
                                         detail: new DOData() { data = new List<DOData>() { new DOData(LogDetail.IP_ADDRESS.ToString(), "localhost") } }, //TODO: Get IP Address
                                         information: new DOData(),
                                         auditLog: changeList.ToList(),
                                         agent: String.Empty,  //TODO: Get agent
                                         agentDetail: "SYSTEM", //TODO: Get agent details
                                         administratorEmail: email,
                                         createdBy: email
                                         )
        });
    }

    #endregion Private Methods
}