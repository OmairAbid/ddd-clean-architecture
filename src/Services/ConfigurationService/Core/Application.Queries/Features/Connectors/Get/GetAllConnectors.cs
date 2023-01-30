using Application.Queries.Contracts.Common;
using Application.Queries.Features.SystemSettings;

namespace Application.Queries.Features.Connectors.Get;

public class GetConnectorsQueryRequest : IRequest<QueryResponse<List<GetConnectorQueryResponse>>>
{
}

public class GetAllConnectorsRequestHandler : IRequestHandler<GetConnectorsQueryRequest, QueryResponse<List<GetConnectorQueryResponse>>>
{
    private readonly IConnectorQueryRepository _connectorQueryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllConnectorsRequestHandler(IConnectorQueryRepository connectorQueryRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
        )
    {
        _connectorQueryRepository = connectorQueryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<QueryResponse<List<GetConnectorQueryResponse>>> Handle(GetConnectorsQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Connector> connectors;
        try
        {
            _unitOfWork.Open();
            connectors = await _connectorQueryRepository.GetAllAsync(cancellationToken);

        }
        finally
        {
            _unitOfWork.Close();
        }
        List<GetConnectorQueryResponse> response = _mapper.Map<List<GetConnectorQueryResponse>>(connectors);

        return new QueryResponse<List<GetConnectorQueryResponse>>() { Data = response };
    }

}

#region Response

public class GetConnectorQueryResponse
{
    public long Id { get; protected set; }
    public string Name { get; set; }
    public string Provider { get; set; }
    public string Identifier { get; set; }
    public int Status { get; set; }
    public bool IsForADSS { get; set; }
    public string Purpose { get; set; }
    public string Type { get; set; }
    public List<string> Purposes { get; set; }
    public IList<ConnectorDetailsResponse> ConnectorDetail { get; set; }
}

#endregion