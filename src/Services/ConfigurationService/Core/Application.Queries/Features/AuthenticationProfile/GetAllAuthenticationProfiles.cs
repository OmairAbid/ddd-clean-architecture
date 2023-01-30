using Application.Queries.Common.Enumerations;

namespace Application.Queries.Features.Role;

public class GetAllAuthenticationProfilesHandler : IRequestHandler<GetAllAuthenticationProfilesRequest, QueryResponse<List<ProfilesQueryResponse>>>
{
    #region Private Fields

    private readonly IProfileQueryRepository _profileQueryRepository;
    private readonly IMapper _mapper;

    #endregion Private Fields

    #region Public Constructors

    public GetAllAuthenticationProfilesHandler(IProfileQueryRepository profileQueryRepository, IMapper mapper)
    {
        _profileQueryRepository = profileQueryRepository;
        _mapper = mapper;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<QueryResponse<List<ProfilesQueryResponse>>> Handle(GetAllAuthenticationProfilesRequest request, CancellationToken cancellationToken)
    {
        IList<ProfilesQueryResponse> profiles = await _profileQueryRepository.GetAllAsync((int)ProfileType.AUTHENTICATION, cancellationToken);
        return new QueryResponse<List<ProfilesQueryResponse>>() { Data = profiles.ToList() };
    }

    #endregion Public Methods
}

public class GetAllAuthenticationProfilesRequest : IRequest<QueryResponse<List<ProfilesQueryResponse>>>
{
}