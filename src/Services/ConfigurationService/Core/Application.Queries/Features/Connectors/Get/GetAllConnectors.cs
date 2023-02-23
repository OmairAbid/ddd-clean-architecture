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
    
}

#endregion
