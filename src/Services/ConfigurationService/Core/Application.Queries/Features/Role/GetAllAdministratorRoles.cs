namespace Application.Queries.Features.Role;

public class GetAllAdministratorRolesHandler : IRequestHandler<GetAllRolesQueryRequest, QueryResponse<List<GetAllAdministratorRoleResponse>>>
{
    #region Private Fields

    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IMapper _mapper;

    #endregion Private Fields

    #region Public Constructors

    public GetAllAdministratorRolesHandler(IRoleQueryRepository roleQueryRepository, IMapper mapper)
    {
        _roleQueryRepository = roleQueryRepository;
        _mapper = mapper;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<QueryResponse<List<GetAllAdministratorRoleResponse>>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
    {
        IList<GetAllAdministratorRoleResponse> settings = await _roleQueryRepository.GetAllAsync();

        return new QueryResponse<List<GetAllAdministratorRoleResponse>>() { Data = settings.ToList() };
    }

    #endregion Public Methods
}

public class GetAllRolesQueryRequest : IRequest<QueryResponse<List<GetAllAdministratorRoleResponse>>>
{
}

public class GetAllAdministratorRoleResponse
{
    #region Public Properties

    public string Description { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }

    #endregion Public Properties
}