namespace Application.Queries.Features.SystemSettings;


using Connector = Domain.QueryEntities.Connector;
using ServicePlan = Domain.QueryEntities.ServicePlan;
using SystemSetting = Domain.QueryEntities.SystemSetting;
using SystemSettingsDetails = Domain.QueryEntities.SystemSettingsDetails;

public class GetSystemSettingQueryRequest : IRequest<QueryResponse<List<GetSystemSettingQueryResponse>>>
{
}

public class GetSystemSettingRequestHandler : IRequestHandler<GetSystemSettingQueryRequest, QueryResponse<List<GetSystemSettingQueryResponse>>>
{
	private readonly ISystemSettingQueryRepository _systemSettingQueryRepository;
    private readonly IConnectorQueryRepository _connectorQueryRepository;
    private readonly IServicePlanQueryRepository _servicePlanQueryRepository;
    private readonly ICurrencyQueryRepository _currencyQueryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

	public GetSystemSettingRequestHandler(ISystemSettingQueryRepository systemSettingRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IConnectorQueryRepository connectorQueryRepository,
        IServicePlanQueryRepository servicePlanQueryRepository,
        ICurrencyQueryRepository currencyQueryRepository
        )
	{
		_systemSettingQueryRepository = systemSettingRepository;
        _connectorQueryRepository = connectorQueryRepository;
        _servicePlanQueryRepository = servicePlanQueryRepository;
        _currencyQueryRepository = currencyQueryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
	}

	public async Task<QueryResponse<List<GetSystemSettingQueryResponse>>> Handle(GetSystemSettingQueryRequest request, CancellationToken cancellationToken)
	{
        IList<SystemSetting> _systemSettings;
        IEnumerable<Connector> _allConnectors;
        IEnumerable<ServicePlan> _allServicePlan;
        IEnumerable<Currency> _currencies;
        try
        {
            _unitOfWork?.Open();
            _systemSettings = await _systemSettingQueryRepository.GetAllAsync();
            _allConnectors = await _connectorQueryRepository.GetNamesForGlobalSettingsAsync(cancellationToken);
            _allServicePlan = await _servicePlanQueryRepository.GetAllAsync(cancellationToken);
            _currencies = await _currencyQueryRepository.GetAllAsync(cancellationToken);
        }
        finally
        {
            _unitOfWork?.Close();
           
        }

        foreach (SystemSetting _setting in _systemSettings)
        {
            if (_setting.AttributeName.Contains("DEFAULT"))
            {
                IEnumerable<Connector> _connectors = null;
                if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_PAYMENT_GATEWAY_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.PAYMENT_GATEWAY.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_SMTP_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.SMTP_SERVER_PURPOSE.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_OTP_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.SMS_GATEWAY_PURPOSE.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_CLOUD_DRIVES_DROPBOX_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.CONNECTOR_PURPOSE_CLOUD_DRIVES_INTEGRATION.ToString() && c.Type == ConnectionProviderType.INTEGRATION_DROPBOX.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_CLOUD_DRIVES_GOOGLE_DRIVE_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.CONNECTOR_PURPOSE_CLOUD_DRIVES_INTEGRATION.ToString() && c.Type == ConnectionProviderType.INTEGRATION_GOOGLE_DRIVE.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_CLOUD_DRIVES_ONEDRIVE_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.CONNECTOR_PURPOSE_CLOUD_DRIVES_INTEGRATION.ToString() && c.Type == ConnectionProviderType.INTEGRATION_ONEDRIVE.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_MARKETING_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.MARKETING.ToString() && c.Type == ConnectionProviderType.MARKETING.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_PUSH_NOTIFICATION_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.PUSH_NOTIFICATION.ToString() && c.Type == ConnectionProviderType.FIREBASE.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_GEO_IP_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.GEOIP_LOCATION.ToString() && c.Type == ConnectionProviderType.MAXMIND.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_GOOGLE_CONNECTOR_CAPTCHA.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.GOOGLE_CONNECTOR_CAPTCHA_PURPOSE.ToString() && c.Type == ConnectionProviderType.SECURITY.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.FILE_SCANNING_CONNECTOR_DEFAULT.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.FILE_SCANNING.ToString() && c.Type == ConnectionProviderType.ICAP.ToString());
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_TIMESTAMPING_CONNECTOR.ToString())
                {
                    _connectors = _allConnectors.Where(c => c.Purpose == ConnectorPurpose.TIMESTAMPING.ToString());
                }

                if (_connectors != null)
                {
                    List<Connector> _enabledConnectors = _connectors.ToList();
                    _enabledConnectors = MoreEnumerable.DistinctBy(_enabledConnectors, connector => connector.Name).ToList();
                    _enabledConnectors.ForEach(c => _setting.AttributeChoices.Add(new SystemSettingsDetails { key = c.Name, Value = c.Name }));
                }

                if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_LANGUAGE.ToString())
                {
                    //_setting.AttributeChoices.AddRange(languageViewModels.Select(x => new SystemSettingsDetails { key = x.Key, Value = x.Value }));
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_THEME.ToString())
                {
                    foreach (string _enumKey in Enum.GetNames(typeof(Themes)))
                    {
                        _setting.AttributeChoices.Add(new SystemSettingsDetails { key = _enumKey, Value = _enumKey });
                    }
                }
                else if (_setting.AttributeName == SystemSettingAttribute.DEFAULT_CURRENCY.ToString())
                {
                    foreach (Currency _currency in _currencies)
                    {
                        _setting.AttributeChoices.Add(new SystemSettingsDetails { key = _currency.Name, Value = _currency.Code });
                    }
                }
            }
            else if (_setting.AttributeName == SystemSettingAttribute.HASH_ALGORITHM.ToString())
            {
                foreach (object _enumValue in Enum.GetValues(typeof(HashingAlgorithm)))
                {
                    _setting.AttributeChoices.Add(new SystemSettingsDetails
                    {
                        key = Convert.ToString(Enum.Parse(typeof(HashingAlgorithm), _enumValue.ToString())),
                        Value = _enumValue.ToString()
                    });
                }
            }
            else if (_setting.AttributeName == SystemSettingAttribute.KEY_SIZE.ToString())
            {
                _setting.AttributeChoices.Add(new SystemSettingsDetails { key = "1024", Value = "1024" });
                _setting.AttributeChoices.Add(new SystemSettingsDetails { key = "2048", Value = "2048" });
            }
            else if ((_setting.AttributeName == SystemSettingAttribute.DOWNGRADE_ENTERPRISE_PLANS_TO.ToString()) || (_setting.AttributeName == SystemSettingAttribute.DOWNGRADE_INDIVIDUAL_PLANS_TO.ToString()))
            {
                List<ServicePlan> _listOfServicePlan = _allServicePlan.Where(p => p.Status == (int)Status.ENABLED &&
                                                       (_setting.AttributeName == SystemSettingAttribute.DOWNGRADE_ENTERPRISE_PLANS_TO.ToString() && p.Type == (int)ServicePlanType.ENTERPRISE ||
                                                        _setting.AttributeName == SystemSettingAttribute.DOWNGRADE_INDIVIDUAL_PLANS_TO.ToString() && p.Type == (int)ServicePlanType.INDIVIDUAL)).ToList();
                _listOfServicePlan.ForEach(s => _setting.AttributeChoices.Add(new SystemSettingsDetails { key = s.Name, Value = s.Id.ToString(CultureInfo.InvariantCulture) }));
            }
            else if (_setting.AttributeName == SystemSettingAttribute.CONFIGURATIONS_SIGNALR_BACKPLANE_TYPE.ToString())
            {
                foreach (object enumValue in Enum.GetValues(typeof(SignalRBackplaneType)))
                {
                    SystemSetting _freshRedis = _systemSettings.FirstOrDefault(s => s.AttributeName == SystemSettingAttribute.CONFIGURATIONS_SIGNALR_REDIS_SERVER_ADDRESS.ToString());
                    SystemSetting _redisService = _systemSettings.FirstOrDefault(s => s.AttributeName == SystemSettingAttribute.CONFIGURATIONS_SIGNALR_EXTERNAL_SERVICE_CONNECTION_STRING.ToString());
                    if (!(_freshRedis == null && enumValue.ToString() == SignalRBackplaneType.REDIS_FRESH.ToString()) && !(_redisService == null && enumValue.ToString() == SignalRBackplaneType.REDIS_EXTERNAL_SERVICE.ToString()))
                    {
                        object[] _attributes = enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                        _setting.AttributeChoices.Add(new SystemSettingsDetails
                        {
                            key = _attributes.Any() ? ((DescriptionAttribute)_attributes[0]).Description : "None",
                            Value = Convert.ToString((int)enumValue)
                        });
                    }
                }
            }
        }

        //TODO: incomplete AllowSettings

        var allowedSettings = AllowSettings(_systemSettings.ToList());
		List<GetSystemSettingQueryResponse> response = _mapper.Map<List<GetSystemSettingQueryResponse>>(allowedSettings);

		return new QueryResponse<List<GetSystemSettingQueryResponse>>() { Data = response };
	}

	private List<SystemSetting> AllowSettings(List<SystemSetting> settings)
	{
        List<SystemSetting> allowedSettings = new();

        allowedSettings = settings.Where(setting => !(setting.AttributeName == SystemSettingAttribute.LICENSE.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.DEK.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.PASS_PHRASE.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.SALT_VALUE.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.KEY_SIZE.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.HASH_ALGORITHM.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.DECRYPTION_KEY.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.VALIDATION_KEY.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.VALIDATION_ALGO.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.INIT_VECTOR.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.DECRYPTION_ALGO.ToString()
                                                          || setting.AttributeName == SystemSettingAttribute.PASSWORD_ITERATIONS.ToString()
                                                          || setting.AttributeName.Contains("LB_"))).ToList();

        //TODO : add roles and licencse for allowed settings

        return allowedSettings;
    }
}


#region Response

public class GetSystemSettingQueryResponse
{
	public string AttributeName { get; set; }
	public string AttributeValue { get; set; }
	public string AttributeDefaultValue { get; set; }
	public string FieldType { get; set; }
	public string GroupName { get; set; }
	public int SortOrder { get; set; }
	public long Id { get; protected set; }
    public List<SystemSettingsDetailsResponse> AttributeChoices { get; set; }

}


public class SystemSettingsDetailsResponse
{
    public string key { get; set; }

    public string Value { get; set; }
}

#endregion