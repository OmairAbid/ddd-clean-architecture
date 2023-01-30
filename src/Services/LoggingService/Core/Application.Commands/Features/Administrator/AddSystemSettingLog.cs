using Application.Commands.Common.Models;
using Application.Commands.Contracts.Common;
using Application.Commands.Contracts.Repositories.Commands;
using EventBus.Logging.Operator;
using EventBus.Models;

using MassTransit;
using Microsoft.Extensions.Options;

namespace Application.Commands.Features.Administrator;

public class SystemSettingLogRequest : IRequest<BasicResponse>
{
    #region Public Properties

    public OperatorLogRequest OperatorLogRequest { get; set; }

    #endregion Public Properties
}

public class UpdateSystemSettingRequestHandler : IRequestHandler<SystemSettingLogRequest, BasicResponse>
{
    #region Private Fields

    private readonly IAdministratorLogRepository _administratorLogCommandRepository;
    private readonly IAuditLogHelper _auditLogHelper;
    private readonly IFileHandler _fileHandler;
    private readonly IOptions<LanguagFilePath> _options;
    private readonly IProfileRepository _profileRepository;
    private readonly IServiceplanRepository _serviceplanRepository;
    private readonly IXMLSerializeHelper _xmlSerializeHelper;

    #endregion Private Fields

    #region Public Constructors

    public UpdateSystemSettingRequestHandler(IAdministratorLogRepository administratorLogCommandRepository, IAuditLogHelper auditLogHelper, IXMLSerializeHelper xmlSerializeHelper,
        IServiceplanRepository serviceplanRepository, IProfileRepository profileRepository, IOptions<LanguagFilePath> options, IFileHandler fileHandler)
    {
        _administratorLogCommandRepository = administratorLogCommandRepository;
        _auditLogHelper = auditLogHelper;
        _xmlSerializeHelper = xmlSerializeHelper;
        _serviceplanRepository = serviceplanRepository;
        _profileRepository = profileRepository;
        _options = options;
        _fileHandler = fileHandler;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse> Handle(SystemSettingLogRequest request, CancellationToken cancellationToken)
    {
        OperatorLogRequest requestData = request.OperatorLogRequest;
        AdministratorLog adminLog = new AdministratorLog()
        {
            Detail = _xmlSerializeHelper.SerializeObjectToXmlString(requestData.Detail),
            Agent = requestData.Agent,
            AgentDetail = requestData.AgentDetail,
            Action = requestData.Action,
            Module = requestData.Module,
            SubModule = requestData.SubModule,
            InfoKey = requestData.Information.Key,
            InfoValue = requestData.Information.Value,
            AdministratorEmail = requestData.AdministratorEmail,
            CreatedBy = requestData.CreatedBy,
            LastModifiedBy = requestData.CreatedBy,
        };

        if (requestData.AuditLog != null)
        {
            await FillAudiLogValues(requestData.AuditLog);
            adminLog.AdministratorLogDetail = new List<AdministratorLogDetail>()
            {
                new AdministratorLogDetail()
                {
                    CreatedBy = requestData.AdministratorEmail,
                    Detail = _xmlSerializeHelper.SerializeObjectToXmlString(requestData.AuditLog),
                }
            };
        }
        await _administratorLogCommandRepository.AddAdministratorLogAsync(adminLog);
        return new BasicResponse() { Success = true };
    }

    #endregion Public Methods

    #region Private Methods

    private async Task FillAudiLogValues(List<AuditDelta> auditLogs)
    {
        List<AuditDelta> _auditLogsList = new List<AuditDelta>();
        foreach (AuditDelta _item in auditLogs)
        {
            if (string.IsNullOrEmpty(_item.ValueBefore))
                _item.ValueBefore = "-";
            if (string.IsNullOrEmpty(_item.ValueAfter))
                _item.ValueAfter = "-";
            switch (_item.DisplayKey)
            {
                case "DOWNGRADE_ENTERPRISE_PLANS_TO":
                case "DOWNGRADE_INDIVIDUAL_PLANS_TO"://TODO: Implement cache here to avoid db queries
                    _item.ValueBefore = _serviceplanRepository.GetByIdAsync(Convert.ToInt32(_item.ValueBefore)).Result?.Name ?? "-";
                    _item.ValueAfter = _serviceplanRepository.GetByIdAsync(Convert.ToInt32(_item.ValueAfter)).Result?.Name ?? "-";
                    break;

                case "DEFAULT_LANGUAGE":
                    List<JSONFileViewModel> supportedLanguages = await _fileHandler.ReadLanguageFile(_options.Value.Path);
                    _item.ValueBefore = supportedLanguages.FirstOrDefault(x => x.Value.ToLower() ==
                    _item.ValueBefore.ToLower())?.Key ?? _item.ValueBefore;
                    _item.ValueAfter = supportedLanguages.FirstOrDefault(x => x.Value.ToLower() ==
                    _item.ValueAfter.ToLower())?.Key ?? _item.ValueAfter; break;

                case "CONFIGURATIONS_REDIS_EXTERNAL_SERVICE_CONNECTION_STRING":
                    _item.ValueBefore = "******";
                    _item.ValueAfter = "*******";
                    break;

                case "PASSWORD":
                    _item.DisplayHeaderKey = "CONFIGURATIONS_DATA_SETTINGS_ARCHIVING_WITH_PASSWORD";
                    _item.ValueBefore = "******";
                    _item.ValueAfter = "*******";
                    break;

                case "PROCESS_EVIDENCE_ESEAL_CAPACITY":
                case "DOCUMENT_LOCK_ESEAL_CAPACITY":
                case "ARCHIVE_PERSONAL_EXCHANGE_FILE":
                case "ARCHIVE_PERSONAL_EXCHANGE_FILE_INFO":
                case "ARCHIVE_PFX_PASSWORD":
                    _item.ValueBefore = _profileRepository.GetByIdAsync(Convert.ToInt32(_item.ValueBefore)).Result?.Name ?? "-";
                    _item.ValueAfter = _profileRepository.GetByIdAsync(Convert.ToInt32(_item.ValueAfter)).Result?.Name ?? "-";
                    break;

                case "PROCESS_EVIDENCE_CONNECTORS":
                case "DOCUMENT_LOCK_SIGNING_SERVER_CONNECTOR":
                    _item.ValueBefore = _profileRepository.GetByIdAsync(Convert.ToInt32(_item.ValueBefore)).Result?.Name ?? "-";
                    _item.ValueAfter = _profileRepository.GetByIdAsync(Convert.ToInt32(_item.ValueAfter)).Result?.Name ?? "-";
                    break;
            }
            if (_item.FieldName != "DEK" && _item.ValueBefore != _item.ValueAfter)
                _auditLogsList.Add(_item);
        }
    }

    #endregion Private Methods
}