using Application.Commands.Common.Enumerations;
using Application.Commands.Contracts.Common;

namespace Application.Commands.Features.CertificationProfile.Delete;
public class DeleteCertificationProfileRequest : IRequest<BasicResponse>
{
    #region Public Properties

    public long Id { get; set; }
    public string UserEmail { get; set; }

    #endregion Public Properties
}


public class DeleteCertificationProfileRequestHandler : IRequestHandler<DeleteCertificationProfileRequest, BasicResponse>
{
    #region Private Fields

    private readonly IUnitOfWork _unitOfWork;
    private readonly IProfileCommandRepository _profileCommandRepository;

    #endregion Private Fields

    #region Public Constructors

    public DeleteCertificationProfileRequestHandler(IProfileCommandRepository profileCommandRepository, IUnitOfWork unitOfWork)
    {
        _profileCommandRepository = profileCommandRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse> Handle(DeleteCertificationProfileRequest request, CancellationToken cancellationToken)
    {

        //TODO : Add Role Check to make sure user has rights to Delete the CertificationProfile.
        //TODO : Check ActionAllowedOnCertificationProfile
        //TODO : Add BO 
        //TODO : Add Logging

        await _profileCommandRepository.DeleteByIdAsync(request.Id, cancellationToken);
        bool response = await _unitOfWork.CommitAsync(cancellationToken);
        return new BasicResponse() { Success = response };
    }

    #endregion
}
