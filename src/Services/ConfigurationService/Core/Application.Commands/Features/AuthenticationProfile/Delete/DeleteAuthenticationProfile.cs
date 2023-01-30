using Application.Commands.Common.Enumerations;

namespace Application.Commands.Features.AuthenticationProfile.Delete;
public class DeleteAuthenticationProfileRequest: IRequest<BasicResponse>
{
    #region Public Properties

    public long Id { get; set; }
    public string UserEmail { get; set; }

    #endregion Public Properties
}


public class DeleteAuthenticationProfileRequestHandler : IRequestHandler<DeleteAuthenticationProfileRequest, BasicResponse>
{
    #region Private Fields

    private readonly IUnitOfWork _unitOfWork;
    private readonly IProfileCommandRepository _profileCommandRepository;

    #endregion Private Fields

    #region Public Constructors

    public DeleteAuthenticationProfileRequestHandler(IProfileCommandRepository profileCommandRepository,
        IUnitOfWork unitOfWork
        )
    {
        _profileCommandRepository = profileCommandRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse> Handle(DeleteAuthenticationProfileRequest request, CancellationToken cancellationToken)
    {

        //TODO : Add Role Check to make sure user has rights to Delete the AuthenticationProfile.
        //TODO : Check ActionAllowedOnAuthenticationProfile
        //TODO : Add BO 

        await _profileCommandRepository.DeleteByIdAsync(request.Id, cancellationToken);

        bool response = await _unitOfWork.CommitAsync(cancellationToken);

        return new BasicResponse() { Success = response};
    }

    #endregion
}
