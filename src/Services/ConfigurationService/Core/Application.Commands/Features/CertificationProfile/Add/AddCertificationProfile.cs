using Application.Commands.Common.Enumerations;
using Application.Commands.Contracts.Common;
using Profile = Domain.Entities.Profile;

namespace Application.Commands.Features.CertificationProfile.Add;

public class AddCertificationProfileRequest : IRequest<BasicResponse<Profile>>
{
    #region Public Properties

    public string adssProfile { get; set; }
    public string assuranceKeysProtection { get; set; }
    public string assuranceLevel { get; set; }
    public string connectorID { get; set; }
    public string description { get; set; }
    public string name { get; set; }
    public int profileID { get; set; }
    public bool status { get; set; }
    public string certificateAlias { get; set; }
    public bool isDefaultCapacityForESeal { get; set; }
    public string certificateName { get; set; }
    public string certificateBase64 { get; set; }
    public string isESealCertificateAutoDownload { get; set; }
    public string UserEmail { get; set; }

    #endregion Public Properties
}

public class AddCertificationProfileRequestHandler : IRequestHandler<AddCertificationProfileRequest, BasicResponse<Profile>>
{
    private readonly IProfileCommandRepository _profileCommandRepository;
    private readonly IDateTimeHelper _dateTimeHelper;
    private DateTime _currentDateTime;
    private readonly IUnitOfWork _unitOfWork;

    public AddCertificationProfileRequestHandler(IProfileCommandRepository profileCommandRepository,
        IDateTimeHelper dateTimeHelper,
        IUnitOfWork unitOfWork
        )
    {
        _profileCommandRepository = profileCommandRepository;
        _dateTimeHelper = dateTimeHelper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BasicResponse<Profile>> Handle(AddCertificationProfileRequest request, CancellationToken cancellationToken)
    {
        //TODO : Add Role Check to make sure user has rights to Add the Certification Profile.
        //TODO : Request data Validation
        //TODO : Logging

        _currentDateTime = _dateTimeHelper.GetCurrentUTCDateTime();
        BasicResponse<Profile> response = new();
        Profile CertificationProfile = new Profile()
        {
            Name = request.name,
            Description = request.description,
            Type = (int)ProfileType.CERTIFICATION,
            ProfileDetail = GetCertificationProfileDetail(request),
            Status = request.status ? 1 : 0,
            CreatedBy = request.UserEmail,
            HMAC = DatabaseValue.HMAC.ToString(),
            LastModifiedBy = request.UserEmail ?? DatabaseValue.ADMIN.ToString(),
            LastModifiedOn = _currentDateTime,
        };
        CertificationProfile = await _profileCommandRepository.AddAsync(CertificationProfile);
        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            response.Data = CertificationProfile;
            response.Success = true;
        }

        return response;
    }

    #region Private Methods

    private List<ProfileDetail> GetCertificationProfileDetail(AddCertificationProfileRequest certificationProfileModel)
    {
        List<ProfileDetail> certificationProfileDetail = new List<ProfileDetail>() {
                    new ProfileDetail(){
                        AttributeName=ProfileConnector.CERTIFICATION_CONNECTOR.ToString(),
                        AttributeValue=certificationProfileModel.connectorID,
                        LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                        LastModifiedOn = _currentDateTime,
                        HMAC = DatabaseValue.HMAC.ToString()
                    },
                    new ProfileDetail(){
                        AttributeName=ProfilesID.LEVEL_OF_ASSURANCE.ToString(),
                        AttributeValue=certificationProfileModel.assuranceLevel,
                        LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                        LastModifiedOn = _currentDateTime,
                        HMAC = DatabaseValue.HMAC.ToString()
                    },
                    new ProfileDetail(){
                        AttributeName=ProfilesID.LEVEL_OF_ASSURANCE_KEYS_PROTECTION_OPTION.ToString(),
                        AttributeValue=certificationProfileModel.assuranceKeysProtection,
                        LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                        LastModifiedOn = _currentDateTime,
                        HMAC = DatabaseValue.HMAC.ToString()
                    },
                };
        bool isEseal = certificationProfileModel.assuranceLevel == ((int)AssuranceLevels.ELECTRONIC_SEAL).ToString() || certificationProfileModel.assuranceLevel == ((int)AssuranceLevels.QUALIFIED_ELECTRONIC_SEAL).ToString() || certificationProfileModel.assuranceLevel == ((int)AssuranceLevels.ADVANCED_ELECTRONIC_SEAL).ToString();
        if (isEseal && certificationProfileModel.isDefaultCapacityForESeal)
            certificationProfileDetail.Add(new ProfileDetail() { 
                 AttributeName = ProfilesID.ESEAL_DEFAULT_PROFILE.ToString(),
                AttributeValue = Flag.TRUE.ToString(),
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });

        if (isEseal && certificationProfileModel.certificateAlias.IsNotNullOrEmpty())
            certificationProfileDetail.Add(new ProfileDetail() { 
                 AttributeName = ProfilesID.ESEAL_CERTIFICATE_ALIAS.ToString(),
                AttributeValue = certificationProfileModel.certificateAlias,
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });

        if (!isEseal)
            certificationProfileDetail.Add(new ProfileDetail() { 
                AttributeName = ProfilesID.CERTIFICATION_PROFILE_ID.ToString(),
                AttributeValue = certificationProfileModel.adssProfile,
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });

        if (isEseal && certificationProfileModel.isESealCertificateAutoDownload.IsNotNullOrEmpty())
        {
            certificationProfileDetail.Add(new ProfileDetail() { 
                AttributeName = ProfilesID.ESEAL_CERTIFICATE_AUTO_DOWNLOAD_ENABLED.ToString(),
                AttributeValue = certificationProfileModel.isESealCertificateAutoDownload,
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
        }

        if (isEseal && certificationProfileModel.certificateName.IsNotNullOrEmpty())
        {
            certificationProfileDetail.Add(new ProfileDetail() { 
                 AttributeName = ProfilesID.ESEAL_CERTIFICATE_FILE_INFO.ToString(),
                AttributeValue = certificationProfileModel.certificateName,
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
            certificationProfileDetail.Add(new ProfileDetail() { 
                 AttributeName = ProfilesID.ESEAL_CERTIFICATE.ToString(),
                AttributeValue = certificationProfileModel.certificateBase64,
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
        }

        return certificationProfileDetail;
    }

    #endregion Private Methods
}