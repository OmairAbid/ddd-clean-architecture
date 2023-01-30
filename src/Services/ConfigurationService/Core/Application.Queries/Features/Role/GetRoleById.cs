namespace Application.Queries.Features.Role;

public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQueryRequest, QueryResponse<AdministratorRoleQueryResponse>>
{
    #region Private Fields

    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IMapper _mapper;

    #endregion Private Fields

    #region Public Constructors

    public GetRoleByIdHandler(IRoleQueryRepository roleQueryRepository, IMapper mapper)
    {
        _roleQueryRepository = roleQueryRepository;
        _mapper = mapper;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<QueryResponse<AdministratorRoleQueryResponse>> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
    {
        AdministratorRoleQueryResponse _role = await _roleQueryRepository.Get(request.RoleId, cancellationToken);
        return new QueryResponse<AdministratorRoleQueryResponse>() { Data = _role };
    }

    #endregion Public Methods
}

public class GetRoleByIdQueryRequest : IRequest<QueryResponse<AdministratorRoleQueryResponse>>
{
    public long RoleId { get; set; }
}