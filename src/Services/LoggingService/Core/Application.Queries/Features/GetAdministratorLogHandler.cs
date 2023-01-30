using Application.Queries.Common.Enumerations;
using Application.Queries.Common.Models;

namespace Application.Queries.Features;

public class GetAdministratorLogHandler : IRequestHandler<GetAdministratorLogsRequest, BasicResponse<List<GetAdministratorLogResponse>>>
{
    private readonly IAdministratorLogQueryRepository _systemSettingRepository;
    private readonly IMapper _mapper;

    public GetAdministratorLogHandler(IAdministratorLogQueryRepository systemSettingRepository, IMapper mapper)
    {
        _systemSettingRepository = systemSettingRepository ?? throw new ArgumentNullException(nameof(systemSettingRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BasicResponse<List<GetAdministratorLogResponse>>> Handle(GetAdministratorLogsRequest request, CancellationToken cancellationToken)
    {
        Tuple<IList<AdministratorQueryResponse>, int> responseTupple = await _systemSettingRepository.GetAsync(request);
        IList<GetAdministratorLogResponse> responseMapped = MapEntityValues(responseTupple.Item1);

        return new BasicResponse<List<GetAdministratorLogResponse>>() { Data = responseMapped.ToList(), Count = responseTupple.Item2, Success = true };
    }

    private IList<GetAdministratorLogResponse> MapEntityValues(IList<AdministratorQueryResponse> administratorLogs)
    {
        List<GetAdministratorLogResponse> _responseLogs = new List<GetAdministratorLogResponse>();
        foreach (AdministratorQueryResponse _log in administratorLogs)
        {
            _responseLogs.Add(new GetAdministratorLogResponse(_log.Id, _log.AdministratorEmail, _log.Name, _log.Module, _log.Action,
                _GetKeyValues(new DOData(_log.InfoKey, _log.InfoValue)), null, _log.Agent, _log.AgentDetail, _log.HMAC, _log.CreatedBy, _log.CreatedOn, _log.LastModifiedBy, _log.LastModifiedOn ?? DateTime.UtcNow, _log.SubModule, null));
        }
        return _responseLogs;
    }

    private List<KeyValuePair<string, string>> _GetKeyValues(DOData data)
    {
        List<KeyValuePair<string, string>> _listOfValues = new List<KeyValuePair<string, string>>();

        if (data.data.Count > 0)
        {
            foreach (DOData _innerData in data.data)
            {
                if (_innerData.Key != LoggingDetailKey.LOG_CERTIFICATE_BASE64.ToString() && _innerData.Key != LoggingDetailKey.LOG_FIELD_NAME.ToString() && _innerData.Key != LoggingDetailKey.LOG_GROUP_ID.ToString())
                {
                    _listOfValues.Add(new KeyValuePair<string, string>(_innerData.Key, _innerData.Value));
                }
            }
        }

        if (!string.IsNullOrEmpty(data.Key) && !string.IsNullOrEmpty(data.Value))
        {
            _listOfValues.Add(new KeyValuePair<string, string>(data.Key, data.Value));
        }
        return _listOfValues;
    }
}

public class GetAdministratorLogsRequest : IRequest<BasicResponse<List<GetAdministratorLogResponse>>>
{
    public string? name { get; set; }
    public string? email { get; set; }
    public string? dateFrom { get; set; }
    public string? dateTo { get; set; }
    public string? module { get; set; }
    public string? activity { get; set; }
    public int start { get; set; }
    public int end { get; set; }
    public bool isAsc { get; set; }
    public string? sortBy { get; set; }
}

public class GetAdministratorLogResponse
{
    public long Id { get; set; }
    public string AdministratorEmail { get; set; }
    public string AdministratorName { get; set; }
    public string Module { get; set; }
    public string Action { get; set; }
    public List<KeyValuePair<string, string>> Information { get; set; }
    public List<DOData> Detail { get; set; }
    public string Agent { get; set; }
    public string AgentDetail { get; set; }
    public string HMAC { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string SubModule { get; set; }
    public List<AuditDelta> AuditDelta { get; set; }

    public GetAdministratorLogResponse(long id, string administratorEmail, string administratorName, string module, string action, List<KeyValuePair<string, string>> information, List<DOData> detail, string agent, string agentDetail, string hMAC, string createdBy, DateTime createdOn, string lastModifiedBy, DateTime lastModifiedOn, string subModule, List<AuditDelta> auditDelta = null)
    {
        Id = id;
        AdministratorEmail = administratorEmail;
        AdministratorName = administratorName;
        Module = module;
        Action = action;
        Detail = detail;
        Agent = agent;
        AgentDetail = agentDetail;
        HMAC = hMAC;
        CreatedBy = createdBy;
        CreatedOn = createdOn;
        LastModifiedBy = lastModifiedBy;
        LastModifiedOn = lastModifiedOn;
        Information = information;
        SubModule = subModule;
        AuditDelta = auditDelta;
    }

    public GetAdministratorLogResponse()
    {
        Id = 0;
        AdministratorEmail = string.Empty;
        Module = string.Empty;
        Action = string.Empty;
        Detail = new List<DOData>();
        Agent = string.Empty;
        AgentDetail = string.Empty;
        HMAC = string.Empty;
        CreatedBy = string.Empty;
        CreatedOn = DateTime.Now;
        LastModifiedBy = string.Empty;
        LastModifiedOn = DateTime.Now;
        Information = new List<KeyValuePair<string, string>>();
        SubModule = string.Empty;
        AuditDelta = null;
    }
}

public class AuditDelta
{
    public string FieldName { get; set; }
    public string ValueBefore { get; set; }
    public string ValueAfter { get; set; }
    public string DisplayKey { get; set; }
    public string DisplayHeaderKey { get; set; }
    public List<AuditDetailDelta> AuditDetail { get; set; }
    public string FieldType { get; set; }
    public bool IsTranslate { get; set; }
}

public class AuditDetailDelta
{
    public string FieldName { get; set; }
    public string ValueBefore { get; set; }
    public string ValueAfter { get; set; }
    public string DisplayKey { get; set; }
}

public class DOData
{
    public List<DOData> data { set; get; }
    public string Key { set; get; }
    public string Value { set; get; }
    public bool Visible { set; get; }
    public int Order { set; get; }
    public string CertificateBase64 { set; get; }
    public string Type { set; get; }
    public string ProcessedState { set; get; }

    public DOData(string Key, string Value, bool Visible, int Order)
    {
        this.Order = Order;
        this.Visible = Visible;
        this.Value = Value;
        this.Key = Key;
        data = new List<DOData>();
    }

    public DOData(string Key, string Value, string Type = "")
    {
        this.Value = Value;
        this.Key = Key;
        this.Type = Type;
        data = new List<DOData>();
    }

    public DOData()
    {
        data = new List<DOData>();
        Key = string.Empty;
        Value = string.Empty;
        Type = string.Empty;
    }
}