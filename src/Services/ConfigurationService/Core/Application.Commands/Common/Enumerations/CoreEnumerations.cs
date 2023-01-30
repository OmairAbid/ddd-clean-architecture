using System.ComponentModel;

namespace Application.Commands.Common.Enumerations;

public enum ProfileCommon
{
    APPEARANCES,
    DOCUMENT_HASHING_ALGORITHM,
    PDF_SIGNATURE_TYPE,
    AUTHENTICATION_MECHANISM,
    DICTIONARY_SIZE,
    WORD_SIGNING_ENABLED,
    XML_CONFIGURATION_PROFILE_SIGNING_ENABLED,
    SERVER_SIGNING_TIMEOUT,
    SERVER_REMOTE_AUTHORIZATION_ENABLED,
    SIGNATURE_TIMESTAMP_CONNECTOR
}

public enum ProfilesID
{
    ADSS_SIGNING_PROFILE_ID,
    ADSS_GOSIGN_PROFILE_ID,
    ADSS_MSSP_PROFILE_ID,
    VERIFICATION_PROFILE_ID,
    CERTIFICATION_PROFILE_ID,
    MS_OFFICE_ADSS_SIGNING_PROFILE_ID,
    MS_OFFICE_ADSS_GOSIGN_PROFILE_ID,
    VIRTUAL_ID_PROFILE_ID,
    VIRTUAL_ID_SERVICE_TYPE,
    LOCAL_SIGNING_T1C_KEYSTORE,
    SIGNATURE_ENHANCEMENT_CONNECTOR,
    SERVER_REMOTE_AUTHORIZATION_SIGNING_PROFILE,
    LEVEL_OF_ASSURANCE_KEYS_PROTECTION_OPTION,
    LEVEL_OF_ASSURANCE,
    ESEAL_CERTIFICATE_ALIAS,
    ESEAL_DEFAULT_PROFILE,
    ESEAL_CERTIFICATE,
    SIGNATURE_TIMESTAMP_CONNECTOR,
    ESEAL_CERTIFICATE_FILE_INFO,
    SIGNATURE_TIMESTAMP_POLICY_ID,
    DOCUMENT_TIMESTAMP_POLICY_ID,
    ESEAL_CERTIFICATE_AUTO_DOWNLOAD_ENABLED
}

public enum PDFSignatureTypes
{
    [StringValue("PAdES-B-LTA")]
    PDF_PADES_PART_4,

    [StringValue("PAdES LTV part 2")]
    PDF_PADES_PART_2,

    [StringValue("PAdES LTV part 3")]
    PDF_PADES_PART_3,

    [StringValue("PAdES-B-LT")]
    PDF_PADES_BASELINE_LT
}

public enum PDFSignatureType
{
    PDF,
    PADES,

    [StringValue("PAdES-B-LTA")]
    PDF_PADES_PART_4,

    [StringValue("PADES part 2")]
    PDF_PADES_PART_2,

    [StringValue("PAdES-B-LT")]
    PDF_PADES_BASELINE_LT
}

public enum HashingAlgorithm
{
    [StringValue("1.3.14.3.2.26")]
    SHA1,

    [StringValue("2.16.840.1.101.3.4.2.1")]
    SHA256,

    [StringValue("2.16.840.1.101.3.4.2.2")]
    SHA384,

    [StringValue("2.16.840.1.101.3.4.2.3")]
    SHA512,
}

public enum SignalRBackplaneType
{
    //[Description("None")]
    //NONE = 1,
    //[Description("SQL Server")]
    //SQL_SERVER = 2,
    [Description("Redis Fresh Installation")]
    REDIS_FRESH = 3,

    [Description("Redis External Service")]
    REDIS_EXTERNAL_SERVICE = 4,

    //[Description("Azure Service Bus")]
    //AZURE_SERVICE_BUS = 5
}

public enum CSCLanguages
{
    [StringValue("en-US")]
    [Description("English")]
    English
}

public enum Themes
{
    DEFAULT,
    SIGNINGHUB
}

public enum ConnectionType
{
    SIGNINGHUB_NATIVE,
    ADSS_SERVER,
    ENTRUST_IDENTITY_GAURD,
    WORLD_PAY,
    SMTP_SERVER,
    SMS_GATEWAY,
    ACTIVE_DIRECTORY,
    CONNECTION_PROVIDER_DROPBOX,
    SALES_FORCE,
    CONNECTION_PROVIDER_GOOGLE_DRIVE,
    OFFICE_365,
    CONNECTOR_PROVIDER_GOOGLE_DRIVE_FOR_PUSH_DOCUMENT,
    CONNECTOR_PROVIDER_DROPBOX_FOR_PUSH_DOCUMENT,
    ADFS,
    MARKETING,
    CONSENT_ID,
    SAML,
    CONNECTION_PROVIDER_TWILLIO_SMS_GATEWAY,
    FIREBASE,
    CONNECTION_PROVIDER_ONEDRIVE,
    LINKED_IN,
    GOOGLE,
    GEO_IP,
    VERISEC_MOBILE,
    STRIPE,
    VERISEC_EID,
    AZURE_BLOB,
    SMS,
    CAPTCHA_PROVIDER_GOOGLE,
    BANKID,
    AZURE_ACTIVE_DIRECTORY,
    ITSME,
    T1C_SIGNING,
    FILE_SCANNING_ICAP,
    CSC_SERVER,
    TSA,
    OAUTH2,
    OIDC
}

public enum ProfileConnector
{
    SERVER_SIGNING_CONNECTOR,
    LOCAL_SIGNING_CONNECTOR,
    MOBILE_SIGNING_CONNECTOR,
    AUTHENTICATION_CONNECTOR,
    VERIFICATION_CONNECTOR,
    CERTIFICATION_CONNECTOR,
    VIRTUAL_ID_PROFILE_CONNECTOR,
    LEVEL_OF_ASSURANCE_KEYS_PROTECTION_OPTION,
    LEVEL_OF_ASSURANCE,
    SIGNATURE_ENHANCEMENT_CONNECTOR
}

public enum VirtualIdServiceType
{
    CSP_SERVICE
}

public enum DropBoxConnectorAttribute
{
    //Pull document
    DROPBOX_CONNECTOR_PARAM_APP_KEY,

    DROPBOX_CONNECTOR_PARAM_SUPPORTED_EXTENSIONS,
    DROPBOX_CONNECTOR_PARAM_ALLOW_MULTISELECT,

    //push documents
    DROPBOX_CONNECTOR_PARAM_APP_SECRET,

    DROPBOX_CONNECTOR_PARAM_REDIRECT_URL
}

public enum GoogleDriveConnectorAttribute
{
    //Pull documents
    GOOGLE_DRIVE_CONNECTOR_PARAM_API_KEY,

    GOOGLE_DRIVE_CONNECTOR_PARAM_CLIENT_ID,
    GOOGLE_DRIVE_CONNECTOR_PARAM_SUPPORTED_EXTENSIONS,
    GOOGLE_DRIVE_CONNECTOR_PARAM_ALLOW_MULTISELECT,

    //push documents
    GOOGLE_DRIVE_CONNECTOR_PARAM_CLIENT_SECRET
}

public enum OneDriveConnectorAttribute
{
    ONEDRIVE_CONNECTOR_PARAM_CLIENT_ID,
    ONEDRIVE_CONNECTOR_PARAM_CLIENT_SECRET,
    ONEDRIVE_CONNECTOR_PARAM_SUPPORTED_EXTENSIONS,
    ONEDRIVE_CONNECTOR_PARAM_ALLOW_MULTISELECT
}

public enum SMSGatewayConnectionParameters
{
    API_URL,
    API_ID,
    USER_NAME,
    PASSWORD
}

public enum TWILLIOSMSGatewayConnectionParameters
{
    API_URL,
    ACCOUNT_SID,
    AUTH_TOKEN,
    FROM,
}

public enum ProfileType
{
    AUTHENTICATION = 1,
    SIGNING = 2,
    VERIFICATION = 3,
    CERTIFICATION = 4,
    RA = 5
}

public enum AuthenticationMechanism
{
    AUTHENTICATION_PASSWORD,
    AUTHENTICATION_SSL_CLIENT,
    AUTHENTICATION_ACTIVE_DIRECTORY,
    AUTHENTICATION_AZURE_ACTIVE_DIRECTORY,
    AUTHENTICATION_SALES_FORCE,
    AUTHENTICATION_OFFICE_365,
    AUTHENTICATION_ADFS,
    AUTHENTICATION_SSL,
    AUTHENTICATION_SAML,
    AUTHENTICATION_LINKED_IN,
    AUTHENTICATION_GOOGLE,
    AUTHENTICATION_VERISEC,
    AUTHENTICATION_IDFY,
    AUTHENTICATION_ITSME,
    AUTHENTICATION_CSC,
    AUTHENTICATION_MOBILE,
    AUTHENTICATION_OAUTH2,
    AUTHENTICATION_OIDC
}

public enum ConnectionProviderType
{
    PASSWORD,
    SSL_CLIENT,
    LOCAL,
    MOBILE,
    SERVER,
    ACTIVE_DIRECTORY,
    SALES_FORCE,
    INTEGRATION_GOOGLE_DRIVE,
    INTEGRATION_DROPBOX,
    OFFICE_365,
    ADFS,
    MARKETING,
    SAML_SP,
    INTEGRATION_ONEDRIVE,
    FIREBASE,
    MAXMIND,
    SECURITY,
    BANKID,
    ITSME,
    ICAP
}

public enum MARKETINGConnectorAttribute
{
    MARKETING_CONNECTOR_PARAM_API_KEY
}

public enum ActiveDirectoryAttribute
{
    DOMAIN_ATTRIBUTES,
    ACTIVE_DIRECTORY_SERVER_URL,
    ACTIVE_DIRECTORY_PORT_NUMBER,
    USER_ID,
    USER_PASSWORD
}

public enum AdfsAttribute
{
    ADFS_CONNECTOR_PARAM_ADFS_URL,
    ADFS_CONNECTOR_PARAM_ADFS_ENCRYPTION_ALGO,
    ADFS_CONNECTOR_PARAM_ADFS_CERT,
    ADFS_CONNECTOR_PARAM_ADFS_CERT_FILE_INFO
}

public enum LinkedInAttribute
{
    LINKED_IN_CONNECTOR_PARAM_CLIENT_ID,
    LINKED_IN_CONNECTOR_PARAM_CLIENT_SECRET
}

public enum OAuth2Attribute
{
    LOGO,
    OAUTH2_AUTHENTICATION_URL,
    OAUTH2_CLIENT_ID,
    OAUTH2_CLIENT_SECRET,
    OAUTH2_SCOPE,
    OAUTH2_RESOURCE,
    OAUTH2_ACCESS_TOKEN_URL,
    OAUTH2_USER_PROFILE_INFO_URL,
    OAUTH2_EMAIL_ATTRIBUTE,
    OAUTH2_NAME_ATTRIBUTE
}

public enum OIDCAttribute
{
    LOGO,
    OIDC_AUTHENTICATION_URL,
    OIDC_CLIENT_ID,
    OIDC_CLIENT_SECRET,
    OIDC_SCOPE,
    OIDC_ACCESS_TOKEN_URL,
    OIDC_DISCOVERY_DOCUMENT_URL
}

public enum OIDCClaims
{
    [StringValue("email")]
    EMAIL,

    [StringValue("name")]
    NAME,

    [StringValue("signicat.national_id")]
    SIGNICAT_NATIONAL_ID,

    [StringValue("nin")]
    NIN
}

public enum OIDCScopes
{
    [StringValue("openid")]
    OPEN_ID,

    [StringValue("profile")]
    PROFILE,

    [StringValue("email")]
    EMAIL
}

public enum GoogleAttribute
{
    GOOGLE_CONNECTOR_PARAM_CLIENT_ID,
    GOOGLE_CONNECTOR_PARAM_CLIENT_SECRET
}

public enum BankIdAttribute
{
    BANKID_CONNECTOR_PARAM_CLIENT_ID,
    BANKID_CONNECTOR_PARAM_CLIENT_SECRET
}

public enum ItsmeAttribute
{
    ITSME_CONNECTOR_PARAM_TOKEN,
    ITSME_CONNECTOR_PARAM_URL
}

public enum CSCServer
{
    CSC_SERVER_SERVER_ADDRESS,
    CSC_SERVER_CLIENT_ID,
    CSC_SERVER_CLIENT_SECRET,
    CSC_SERVER_LEVEL_OF_ASSURANCE,
    CSC_SERVER_AUTHORIZATION_REQUIRED,
    CSC_SERVER_ACCOUNT_ID,
    LOGO,
    LOGO_FILE_INFO,

    [StringValue("invalid_otp")]
    INVALID_OTP,

    [StringValue("invalid_pin")]
    INVALID_PIN,

    [StringValue("invalid_request")]
    INVALID_REQUEST,

    [StringValue("Bearer")]
    TOKEN_TYPE_BEARER,

    [StringValue("SAD")]
    TOKEN_TYPE_SAD,

    [StringValue("1")]
    SCAL_1,

    [StringValue("2")]
    SCAL_2,

    [StringValue("oauth2code")]
    AUTH_TYPE_OAUTH_2CODE,

    [StringValue("CSC/OAuth/CallBack")]
    SH_CSC_CALL_BACK_URL
}

public enum CSCServerRequestURLs
{
    [StringValue("credentials/list")]
    CREDENTIALS_LIST,

    [StringValue("credentials/info")]
    CREDENTIALS_INFO,

    [StringValue("info")]
    SERVER_INFO,

    [StringValue("credentials/sendOTP")]
    CREDENTIALS_SEND_OTP,

    [StringValue("credentials/authorize")]
    CREDENTIALS_AUTHORIZE,

    [StringValue("oauth2/token")]
    OAUTH2_TOKEN,

    [StringValue("oauth2/revoke")]
    OAUTH2_REVOKE_TOKEN,

    [StringValue("auth/revoke")]
    AUTH_REVOKE_TOKEN,

    [StringValue("signatures/signHash")]
    SIGNATURES_SIGN_HASH,
}

public enum SalesForceAttribute
{
    SALES_FORCE_PARAMS,
    SALES_FORCE_CONNECTOR_PARAM_REDIRECT_URL,
    SALES_FORCE_CONNECTOR_PARAM_CONSUMER_KEY
}

public enum Office365Attribute
{
    OFFICE_365_CONNECTOR_PARAM_CLIENT_ID,
    OFFICE_365_CONNECTOR_PARAM_CLIENT_SECRET,
    OFFICE_365_CONNECTOR_PARAM_TENANT_ID,
    OFFICE_365_CONNECTOR_PARAM_APP_TYPE,
    SINGLE_TENANT,
    MULTI_TENANT
}

public enum AzureActiveDirectoryAttribute
{
    AZURE_ACTIVE_DIRECTORY_CONNECTOR_PARAM_CLIENT_ID,
    AZURE_ACTIVE_DIRECTORY_CONNECTOR_PARAM_CLIENT_SECRET,
    AZURE_ACTIVE_DIRECTORY_CONNECTOR_PARAM_TENANT_ID
}

public enum SERVICE_PLAN_DETAIL_TYPE
{
    FEATURE,
    SETTING
}

public enum ADSSConnectorAttribute
{
    HOST_URL,
    ORIGINATOR_ID,
    REMOTE_ADDRESS,

    //not user any more
    SSL_CLIENT_CERTIFICATE_LOCATION,

    SSL_CLIENT_CERTIFICATE,
    SSL_CLIENT_CERTIFICATE_PASSWORD,
    TIMEOUT,
    CLIENT_SECRET
}

public enum AdocsBuildVersion
{
    MAJOR,
    MINOR,
    SPRINT,
    PATCH,
    BUILD
}

public enum EnterpriseRoleNames
{
    [StringValue("Enterprise Admins")]
    ENTERPRISE_ADMIN,

    [StringValue("Enterprise Users")]
    ENTERPRISE_USER,

    [StringValue("It is the role for the enterprise administrators")]
    ADMIN_ROLE_DESCRIPTION,

    [StringValue("It is the role for the enterprise users")]
    CHILD_ROLE_DESCRIPTION
}

public enum HubSpotProperty
{
    [StringValue("lifecyclestage")]
    LIFECYCLE_STAGE,

    [StringValue("firstname")]
    FIRST_NAME,

    [StringValue("email")]
    EMAIL
}

public enum HubSpotValue
{
    [StringValue("customer")]
    PAID_ACCOUNT,

    [StringValue("subscriber")]
    FREE_ACCOUNT,

    [StringValue("opportunity")]
    OPPORTUNITY,

    [StringValue("other")]
    OTHER
}

public enum GEOIP
{
    LICENSE_KEY,
    USER_ID,
}

public enum SMTPAttribute
{
    AUTHENTICATE_ON_SSL,
    SERVER_HOST,
    PORT_NUMBER,
    AUTHENTICATION_REQUIRED,
    AUTHENTICATION_EMAIL,
    AUTHENTICATION_EMAIL_PASSWORD,
    FROM_EMAIL
}

public enum SSLAuthentication
{
    [StringValue("with password")]
    PASSWORD_ENABLED,
}

public enum ICAPConnectorAttribute
{
    HOST_URL,
    HOST_PORT
}

public enum AssuranceLevels
{
    ADVANCED_ELECTRONIC_SIGNATURE = 1,
    HIGH_TRUST_ADVANCED = 2,
    QUALIFIED_ELECTRONIC_SIGNATURE = 3,
    ELECTRONIC_SEAL = 4,
    ADVANCED_ELECTRONIC_SEAL = 5,
    QUALIFIED_ELECTRONIC_SEAL = 6,
    ELECTRONIC_SIGNATURE = 7
}

public enum WorkSpaceActions
{
    ADD = 1,
    UPDATE = 2,
    DELETE = 3
}

public enum AssuranceLevelProtectionKeys
{
    NO_PASSWORD = 0,
    USER_PASSWORD = 1,
    SYSTEM_PASSWORD = 2,
    REMOTE_AUTHORISATION = 3
}

public enum UserLevelOfAssurance
{
    [StringValue("7")]
    Individual,

    [StringValue("1,2,3,4,5,6,7")]
    EnterpriseOwner,

    [StringValue("7")]
    EnterpriseChild,

    [StringValue("1,2,3,4,5,6,7")]
    ALL,

    [StringValue("1,2,3,4,5,6")]
    ALLCertified,
}