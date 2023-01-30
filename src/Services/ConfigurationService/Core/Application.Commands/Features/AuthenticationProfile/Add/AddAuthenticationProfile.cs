using Application.Commands.Common.Enumerations;
using MassTransit;
using Profile = Domain.Entities.Profile;

namespace Application.Commands.Features.AuthenticationProfile.Add;

public class AddAuthenticationProfileRequest : IRequest<BasicResponse<Profile>>
{
    #region Public Properties

    public Dictionary<string, string> adDictionary { get; set; }
    public string connectorID { get; set; }
    public string description { get; set; }
    public bool isPrivate { get; set; }
    public string mechanism { get; set; }
    public string name { get; set; }
    public bool status { get; set; }
    public bool verifySLL { get; set; }
    public bool verifySSLPassword { get; set; }

    public string UserEmail { get; set; }

    #endregion Public Properties
}

public class AddAuthenticationProfileRequestHandler : IRequestHandler<AddAuthenticationProfileRequest, BasicResponse<Profile>>
{
    private readonly IProfileCommandRepository _profileCommandRepository;
    private readonly IDateTimeHelper _dateTimeHelper;
    private DateTime _currentDateTime;
    private readonly IUnitOfWork _unitOfWork; 

    public AddAuthenticationProfileRequestHandler(IProfileCommandRepository profileCommandRepository,
        IDateTimeHelper dateTimeHelper,
        IUnitOfWork unitOfWork)
    {
        _profileCommandRepository = profileCommandRepository;
        _dateTimeHelper = dateTimeHelper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BasicResponse<Profile>> Handle(AddAuthenticationProfileRequest request, CancellationToken cancellationToken)
    {
        //TODO : Add Role Check to make sure user has rights to Add the Authentication Profile.
        //TODO : Request data Validation
        //TODO : Logging

        _currentDateTime = _dateTimeHelper.GetCurrentUTCDateTime();
        BasicResponse<Profile> response = new();
        Profile AuthenticationProfile = new Profile()
        {
            Name = request.name,
            Description = request.description,
            Type = (int)ProfileType.AUTHENTICATION,
            ProfileDetail = GetAuthenticationProfileDetail(request),
            Status = request.status ? 1 : 0,
            IsPrivate = request.isPrivate ? 1 : 0,
            CreatedBy = request.UserEmail,
            HMAC = DatabaseValue.HMAC.ToString(),
            LastModifiedBy = request.UserEmail ?? DatabaseValue.ADMIN.ToString(),
            LastModifiedOn = _currentDateTime,
        };
        await _profileCommandRepository.AddAsync(AuthenticationProfile);
        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            response.Data = AuthenticationProfile;
            response.Success = true;
        }

        return response;
    }

    #region Private Methods

    private List<ProfileDetail> GetAuthenticationProfileDetail(AddAuthenticationProfileRequest authenticationProfileModel)
    {
        List<ProfileDetail> AuthencationProfileDetail = new List<ProfileDetail> {
                    new ProfileDetail() { 
                        AttributeName = ProfileCommon.AUTHENTICATION_MECHANISM.ToString(),
                        AttributeValue = authenticationProfileModel.mechanism,
                        LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                        LastModifiedOn = _currentDateTime,
                        HMAC = DatabaseValue.HMAC.ToString()
                    }
                };
        if (authenticationProfileModel.connectorID != "")
        {
            AuthencationProfileDetail.Add(new ProfileDetail()
            {
                AttributeName = ProfileConnector.AUTHENTICATION_CONNECTOR.ToString(),
                AttributeValue = string.IsNullOrEmpty(authenticationProfileModel.connectorID) ? string.Empty : authenticationProfileModel.connectorID,
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
        }

        if (authenticationProfileModel.mechanism.Equals(AuthenticationMechanism.AUTHENTICATION_SSL.ToString()))
        {
            AuthencationProfileDetail.Add(new ProfileDetail() { 
                AttributeName = SSLAuthenticationAttribute.VERIFY_SSL.ToString().ToUpper(),
                AttributeValue = authenticationProfileModel.verifySLL.ToString().ToPascal(),
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
            AuthencationProfileDetail.Add(new ProfileDetail() { 
                AttributeName = SSLAuthenticationAttribute.VERIFY_SSL_PASSWORD.ToString().ToUpper(),
                AttributeValue = authenticationProfileModel.verifySSLPassword.ToString().ToPascal(),
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
        }

        if (authenticationProfileModel.mechanism.Equals(AuthenticationMechanism.AUTHENTICATION_ACTIVE_DIRECTORY.ToString()))
        {
            List<ProfileDetailValue> AuthencationProfileDetailValue = new List<ProfileDetailValue>();
            if (authenticationProfileModel.adDictionary != null)
            {
                AuthencationProfileDetailValue.Add(new ProfileDetailValue() { 
                    AttributeName = "Domain",
                    AttributeValue = authenticationProfileModel.adDictionary["Domain"],
                    LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                    LastModifiedOn = _currentDateTime,
                    HMAC = DatabaseValue.HMAC.ToString()
                });
                AuthencationProfileDetailValue.Add(new ProfileDetailValue() { 
                    AttributeName = "Container",
                    AttributeValue = GetActiveDirectoryContainerName(),
                    LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                    LastModifiedOn = _currentDateTime,
                    HMAC = DatabaseValue.HMAC.ToString()
                });
                AuthencationProfileDetail.Add(new ProfileDetail() { 
                    AttributeName = ActiveDirectoryAttribute.DOMAIN_ATTRIBUTES.ToString(),
                    AttributeValue = "",
                    ProfileDetailValue = AuthencationProfileDetailValue,
                    LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                    LastModifiedOn = _currentDateTime,
                    HMAC = DatabaseValue.HMAC.ToString()
                });
            }
        }

        if (authenticationProfileModel.mechanism.Equals(AuthenticationMechanism.AUTHENTICATION_SAML.ToString())
            && authenticationProfileModel.adDictionary != null)
        {
            AuthencationProfileDetail.Add(new ProfileDetail() { 
                AttributeName = SAMLAttribute.LOGO_BASE64.ToString(),
                AttributeValue = authenticationProfileModel.adDictionary["logoBase64"],
                LastModifiedBy = DatabaseValue.ADMIN.ToString(),
                LastModifiedOn = _currentDateTime,
                HMAC = DatabaseValue.HMAC.ToString()
            });
        }
        return AuthencationProfileDetail;

        string GetActiveDirectoryContainerName()
        {
            string container = authenticationProfileModel.adDictionary["Container"];
            if (container.IsNotNullOrEmpty())
            {
                List<string> groups = container.Split(',').ToList();
                return string.Join(",", groups.Select(x => x.TrimStart()));
            }
            else
            {
                return container;
            }
        }
    }

    #endregion Private Methods
}