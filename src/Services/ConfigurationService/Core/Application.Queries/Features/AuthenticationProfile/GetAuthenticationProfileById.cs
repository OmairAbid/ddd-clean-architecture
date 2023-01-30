using Application.Queries.Common.Enumerations;

namespace Application.Queries.Features.Role;

public class GetAuthenticationProfileByIdHandler : IRequestHandler<GetAuthenticationProfileByIdRequest, QueryResponse<ProfilesQueryResponse>>
{
    #region Private Fields

    private readonly IProfileQueryRepository _profileQueryRepository;
    private readonly IMapper _mapper;

    #endregion Private Fields

    #region Public Constructors

    public GetAuthenticationProfileByIdHandler(IProfileQueryRepository profileQueryRepository, IMapper mapper)
    {
        _profileQueryRepository = profileQueryRepository;
        _mapper = mapper;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<QueryResponse<ProfilesQueryResponse>> Handle(GetAuthenticationProfileByIdRequest request, CancellationToken cancellationToken)
    {
        ProfilesQueryResponse profile = await _profileQueryRepository.Get(request.Id, cancellationToken);
        return new QueryResponse<ProfilesQueryResponse>() { Data = profile };
    }

    #endregion Public Methods
}

public class GetAuthenticationProfileByIdRequest : IRequest<QueryResponse<ProfilesQueryResponse>>
{
    public long Id { get; set; }
}