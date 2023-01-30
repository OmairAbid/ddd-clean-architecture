

namespace Application.Queries.Features.Connectors.Get;
public class GetProviderQueryRequest:IRequest<QueryResponse<ConnectionProviderQueryResponse>>
{
    public string ProviderName { get; set; }
    public string UserEmail    { get; set; }
}

public class GetProviderRequestHandler : IRequestHandler<GetProviderQueryRequest, QueryResponse<ConnectionProviderQueryResponse>>
{
    private readonly IConnectorQueryRepository _connectorQueryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEnumerationHelper _enumerationHelper;

    public GetProviderRequestHandler(IConnectorQueryRepository connectorQueryRepository,
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

    public async Task<QueryResponse<ConnectionProviderQueryResponse>> Handle(GetProviderQueryRequest request, CancellationToken cancellationToken)
    {

        ConnectionProvider _connectionProvider;
        try
        {
            _unitOfWork.Open();
            _connectionProvider = await _connectorQueryRepository.GetProviderAsync(providerName: request.ProviderName, cancellationToken);

        }
        finally
        {
            _unitOfWork.Close();
        }
        var provider = GetProvider(providerName: request.ProviderName.ToEnum<ConnectionType>(), _connectionProvider);

        ConnectionProviderQueryResponse connectionProvider = _mapper.Map<ConnectionProviderQueryResponse>(provider);

        return new QueryResponse<ConnectionProviderQueryResponse>() { Data = connectionProvider };
    }

    private ConnectionProvider GetProvider(ConnectionType providerName, ConnectionProvider connectionProvider)
    {
        if(connectionProvider?.AttributeKey == providerName.ToString())
        {
            switch (providerName)
            {
                case ConnectionType.WORLD_PAY:
                    connectionProvider.ConnectionProviderParameter
                            .FirstOrDefault(o => o.AttributeKey == WorldPayConnectionParameters.PAYMENT_MODE.ToString())
                            .AttributeChoices = GetWorldPayModesList();

                    break;

                case ConnectionType.STRIPE:
                    connectionProvider.ConnectionProviderParameter
                            .FirstOrDefault(o => o.AttributeKey == StripeConnectionParameters.STRIPE_PAYMENT_MODE.ToString())
                            .AttributeChoices = GetStripeModesList();
                    break;

                case ConnectionType.CSC_SERVER:
                    connectionProvider.ConnectionProviderParameter
                            .FirstOrDefault(o => o.AttributeKey == CSCServer.CSC_SERVER_LEVEL_OF_ASSURANCE.ToString())
                            .AttributeChoices = GetCSCServerLevelOfAssuranceOptionsList();
                    break;

                case ConnectionType.SMS:
                    connectionProvider.ConnectionProviderParameter
                        .FirstOrDefault(o => o.AttributeKey == SMSProviderParameter.SMS_PROVIDER_HTTP_METHOD.ToString())
                        .AttributeChoices = GetHttpVerbsList();

                    connectionProvider.ConnectionProviderParameter
                        .FirstOrDefault(o => o.AttributeKey == SMSProviderParameter.SMS_PROVIDER_HEADER_AUTHORIZATION.ToString())
                        .AttributeChoices = GetAuthorizationList();

                    connectionProvider.ConnectionProviderParameter
                        .FirstOrDefault(o => o.AttributeKey == SMSProviderParameter.SMS_PROVIDER_HEADER_CONTENT_TYPE.ToString())
                        .AttributeChoices = GetContentTypeList();

                    break;

                default:
                    break;
            }
            connectionProvider.Purposes = connectionProvider.ConnectionProviderDetail.Select(o => o.Purpose).Distinct().ToList();
            connectionProvider.ConnectionProviderParameter = connectionProvider.ConnectionProviderParameter.OrderBy(x => x.SortOrder).ToList();

            return connectionProvider;
        }
        return null;
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

public class ConnectionProviderQueryResponse
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
