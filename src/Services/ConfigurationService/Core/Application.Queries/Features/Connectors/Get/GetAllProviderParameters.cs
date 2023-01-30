

namespace Application.Queries.Features.Connectors.Get;
public class GetAllProviderParametersQueryRequest:IRequest<QueryResponse<IEnumerable<ConnectionProviderParametersQueryResponse>>>
{
    public string UserEmail    { get; set; }
}

internal sealed class GetAllProviderParametersRequestHandler : IRequestHandler<GetAllProviderParametersQueryRequest, QueryResponse<IEnumerable<ConnectionProviderParametersQueryResponse>>>
{
    private readonly IConnectorQueryRepository _connectorQueryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEnumerationHelper _enumerationHelper;

    public GetAllProviderParametersRequestHandler(IConnectorQueryRepository connectorQueryRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IEnumerationHelper enumerationHelper
        )
    {
        _connectorQueryRepository = connectorQueryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _enumerationHelper = enumerationHelper;
    }

    public async Task<QueryResponse<IEnumerable<ConnectionProviderParametersQueryResponse>>> Handle(GetAllProviderParametersQueryRequest request, CancellationToken cancellationToken)
    {

        IEnumerable<ConnectionProvider> _connectionProviders;
        try
        {
            _unitOfWork.Open();
            _connectionProviders = await _connectorQueryRepository.GetAllProvidersAsync(cancellationToken);

        }
        finally
        {
            _unitOfWork.Close();
        }
        var providerParams = GetProviderParameters(_connectionProviders.ToList());

        var connectionProviderParameters = _mapper.Map<IEnumerable<ConnectionProviderParametersQueryResponse>>(providerParams);

        return new QueryResponse<IEnumerable<ConnectionProviderParametersQueryResponse>>() { Data = connectionProviderParameters };
    }

    private List<ConnectionProviderParameter> GetProviderParameters(List<ConnectionProvider> connectionProviders)
    {
        List<ConnectionProviderParameter> _connectionProviderParameters;
        List<ConnectionProviderParameter> _worldPayConnectionProviderParameters;
        List<ConnectionProviderParameter> _stripeConnectionProviderParameters;
        List<ConnectionProviderParameter> _CSCServerConnectionProviderParameters;
        List<ConnectionProviderParameter> _httpVerbParameters;
        List<ConnectionProviderParameter> _httpAuthorization;
        List<ConnectionProviderParameter> _contentTypesParameter;

        _connectionProviderParameters = new List<ConnectionProviderParameter>();
        foreach (ConnectionProvider _connectionProvider in connectionProviders)
        {
            _connectionProviderParameters.AddRange(_connectionProvider.ConnectionProviderParameter);
        }

        _worldPayConnectionProviderParameters = _connectionProviderParameters.Where(o => o.AttributeKey
            == WorldPayConnectionParameters.PAYMENT_MODE.ToString()).ToList();
        //Add Choices for WorldPay ConnectionProviderParameters
        foreach (ConnectionProviderParameter _parameter in _worldPayConnectionProviderParameters)
        {
            _parameter.AttributeChoices = GetWorldPayModesList();
        }

        _stripeConnectionProviderParameters = _connectionProviderParameters.Where(o => o.AttributeKey
            == StripeConnectionParameters.STRIPE_PAYMENT_MODE.ToString()).ToList();
        foreach (ConnectionProviderParameter _parameter in _stripeConnectionProviderParameters)
        {
            _parameter.AttributeChoices = GetStripeModesList();
        }

        _CSCServerConnectionProviderParameters = _connectionProviderParameters.Where(o => o.AttributeKey
            == CSCServer.CSC_SERVER_LEVEL_OF_ASSURANCE.ToString()).ToList();
        foreach (ConnectionProviderParameter _parameter in _CSCServerConnectionProviderParameters)
        {
            _parameter.AttributeChoices = GetCSCServerLevelOfAssuranceOptionsList();
        }

        //values for http verb
        _httpVerbParameters = _connectionProviderParameters.Where(o => o.AttributeKey
            == SMSProviderParameter.SMS_PROVIDER_HTTP_METHOD.ToString()).ToList();
        foreach (ConnectionProviderParameter _parameter in _httpVerbParameters)
        {
            _parameter.AttributeChoices = GetHttpVerbsList();
        }
        // Values for drop down authorizaiton
        _httpAuthorization = _connectionProviderParameters.Where(o => o.AttributeKey
            == SMSProviderParameter.SMS_PROVIDER_HEADER_AUTHORIZATION.ToString()).ToList();
        foreach (ConnectionProviderParameter _parameter in _httpAuthorization)
        {
            _parameter.AttributeChoices = GetAuthorizationList();
        }

        // Values for drop content Type
        _contentTypesParameter = _connectionProviderParameters.Where(o => o.AttributeKey
            == SMSProviderParameter.SMS_PROVIDER_HEADER_CONTENT_TYPE.ToString()).ToList();
        foreach (ConnectionProviderParameter _parameter in _contentTypesParameter)
        {
            _parameter.AttributeChoices = GetContentTypeList();
        }

        return _connectionProviderParameters;
    }
    private List<KeyValuePair<string, string>> GetWorldPayModesList()
    {
        return new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>(PaymentModes.WORLD_PAY_LIVE.ToString(), PaymentModes.WORLD_PAY_LIVE.ToString()),
                            new KeyValuePair<string, string>(PaymentModes.WORLD_PAY_TEST.ToString(), PaymentModes.WORLD_PAY_TEST.ToString())
                        };
    }

    /// <summary> Gets HTTP verbs list. </summary>
    /// <returns> The HTTP verbs list. </returns>

    private List<KeyValuePair<string, string>> GetHttpVerbsList()
    {
        return new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(SMSPrviderHTTPVerb.GET), _enumerationHelper.GetStringValue(SMSPrviderHTTPVerb.GET)),
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(SMSPrviderHTTPVerb.POST), _enumerationHelper.GetStringValue(SMSPrviderHTTPVerb.POST))
                        };
    }

    /// <summary> Gets stripe modes list. </summary>
    /// <returns> The stripe modes list. </returns>

    private List<KeyValuePair<string, string>> GetStripeModesList()
    {
        return new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>(PaymentModes.STRIPE_PAYMENT_MODE_LIVE.ToString(), PaymentModes.STRIPE_PAYMENT_MODE_LIVE.ToString()),
                            new KeyValuePair<string, string>(PaymentModes.STRIPE_PAYMENT_MODE_TEST.ToString(), PaymentModes.STRIPE_PAYMENT_MODE_TEST.ToString())
                        };
    }

    /// <summary> Gets csc server level of assurance options list. </summary>
    /// <returns> The csc server level of assurance options list. </returns>

    private List<KeyValuePair<string, string>> GetCSCServerLevelOfAssuranceOptionsList()
    {
        return new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>(AssuranceLevels.ADVANCED_ELECTRONIC_SIGNATURE.ToString(),AssuranceLevels.ADVANCED_ELECTRONIC_SIGNATURE.ToString()),
                            new KeyValuePair<string, string>( AssuranceLevels.HIGH_TRUST_ADVANCED.ToString(), AssuranceLevels.HIGH_TRUST_ADVANCED.ToString()),
                            new KeyValuePair<string, string>(AssuranceLevels.QUALIFIED_ELECTRONIC_SIGNATURE.ToString(),AssuranceLevels.QUALIFIED_ELECTRONIC_SIGNATURE.ToString())
                        };
    }

    /// <summary> Gets authorization list. </summary>
    /// <returns> The authorization list. </returns>

    private List<KeyValuePair<string, string>> GetAuthorizationList()
    {
        return new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(AuthorizationTypes.NO_AUTH), _enumerationHelper.GetStringValue(AuthorizationTypes.NO_AUTH)),
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(AuthorizationTypes.BEARER_TOKEN), _enumerationHelper.GetStringValue(AuthorizationTypes.BEARER_TOKEN)),
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(AuthorizationTypes.BASIC), _enumerationHelper.GetStringValue(AuthorizationTypes.BASIC))
                        };
    }

    /// <summary> Gets content type list. </summary>
    /// <returns> The content type list. </returns>

    private List<KeyValuePair<string, string>> GetContentTypeList()
    {
        return new List<KeyValuePair<string, string>> {
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(ContentTypes.APPLICATION_JSON), _enumerationHelper.GetStringValue(ContentTypes.APPLICATION_JSON)),
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(ContentTypes.APPLICATION_FORM_URL_ENCODED), _enumerationHelper.GetStringValue(ContentTypes.APPLICATION_FORM_URL_ENCODED)),
                            new KeyValuePair<string, string>(_enumerationHelper.GetStringValue(ContentTypes.MULTIPART_FORM_DATA), _enumerationHelper.GetStringValue(ContentTypes.MULTIPART_FORM_DATA))
                        };
    }
}


#region Response

public class ConnectionProviderParametersQueryResponse
{
    public long Id { get; set; }

    public string AttributeName { get; set; }
    /// <summary>
    /// Possible values are 0 = NO, 1 = YES
    /// </summary>
    public int IsForADSS { get; set; }
    public string AttributeKey { get; set; }
    /// <summary>
    /// Possible values are 0, 1 (ENABLED = 1, DISABLED = 0)
    /// </summary>
    public int Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string HMAC { get; set; }
    public List<ConnectionProviderParameterResponse> ConnectionProviderParameter { get; set; }
    public List<ConnectionProviderDetailResponse> ConnectionProviderDetail { get; set; }
    public List<string> Purposes { get; set; }

}

#endregion
