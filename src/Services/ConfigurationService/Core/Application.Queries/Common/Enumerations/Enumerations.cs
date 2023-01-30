using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Queries.Common.Enumerations;

public enum FolderItemFilterColumn
{
    Name,
    Owner,
    Size,
    LastModifiedOn
}

/// <summary>
/// FALSE = 0 | TRUE = 1
/// </summary>
public enum Flag
{
    [StringValue("False")]
    FALSE = 0,

    [StringValue("True")]
    TRUE = 1
}

public enum OnScreenNotificationTypes
{
    INFO = 0,
    ERROR = 1,
    WARNING = 2
}

public enum ServicePlanDetails
{
    DOCUMENT_DELETION,
    DOCUMENT_DELETION_EMAIL_NOTIFICATION,
    DOCUMENT_DELETION_DURATION,
    DOCUMENT_DELETION_EMAIL_DURATION,
    DOCUMENT_DELETION_EMAIL_ATTACHMENT,
    DOCUMENT_DELETION_EMAIL_EVIDENCE_REPORT_ATTACHMENT,
    OTP_SEND_EMAIL,
    OTP_LENGTH,
    OTP_RETRY_TIME,
    OTP_EXPIRY_TIME,
    ALLOWED_PRIVATE_AUTHENTICATION_PROFILES,
    SERVER_AES_CERTIFICATION_PROFILE,
    WITNESS_SIGN_PROFILE,
    USER_DELETION,
    USER_DELETION_DURATION,
    USER_DELETION_EMAIL_DURATION,
    USER_DELETION_EMAIL,
    SERVER_CSP_REGISTRATION_PROFILE,
    SERVICE_PLAN_FEATURE_CLOUD_DRIVES,
    SERVER_CSP_USER_AUTO_DELETION,

    SERVER_SIGNING_SERVER,
    SERVER_AES_ENABLED,
    SERVER_CSP_ENABLED,
    LOCAL_SIGNING_SERVER,

    //ESEAL
    SERVER_ESEAL_ENABLED,

    SERVER_ESEAL_CERTIFICATION_PROFILE,

    //Advanced ESEAL
    SERVER_ADVANCED_ESEAL_ENABLED,

    SERVER_ADVANCED_ESEAL_CERTIFICATION_PROFILE,

    //Qualified ESEAL
    SERVER_QUALIFIED_ESEAL_ENABLED,

    SERVER_QUALIFIED_ESEAL_CERTIFICATION_PROFILE,

    //AATL
    SERVER_AATL_ENABLED,

    SERVER_AATL_CERTIFICATION_PROFILE,

    //QES
    SERVER_QES_ENABLED,

    SERVER_QES_CERTIFICATION_PROFILE,
    SERVICE_PLAN_SETTINGS_DOCUMENT_LOGS_DELETION_ENABLE,
    SERVICE_PLAN_SIGNATURES_SIGNATURE_APPEARANCE,
    SIGNATURE_LEVEL_OF_ASSURANCE,
    SERVICE_PLAN_SETTINGS_ALLOW_ADD_UNIQUE_IDENTIFIER
}

public enum ServicePlanConstraints
{
    SERVICEPLAN_SIGNATURES,
    SERVICEPLAN_DISK_SPACE,
    SERVICEPLAN_UPLOAD_SIZE,
    SERVICEPLAN_TEMPLATES,
    SERVICEPLAN_DOCUMENTS_SHARE,
    SERVICEPLAN_USERS,
    OTP_LENGTH,
    OTP_RETRY_TIME,
    OTP_EXPIRY_TIME,
    AUTHORIZED_REMOTE_SIGNING,
    OWNER_EVIDENCE_REPORT,
    SERVICEPLAN_SIMPLE_ELECTRONIC_SIGNATURES
}

public enum EnterpriseUserConstraints
{
    ENTERPRISE_USER_SIGNATURES,
    ENTERPRISE_USER_DISK_SPACE,
    ENTERPRISE_USER_UPLOAD_SIZE,
    ENTERPRISE_USER_TEMPLATES,
    ENTERPRISE_USER_DOCUMENTS_SHARE,
    ENTERPRISE_USER_SIMPLE_ELECTRONIC_SIGNATURES,
    SERVICEPLAN_SIMPLE_ELECTRONIC_SIGNATURES
}

public enum SERVICE_PLAN_FEATURES
{
    ALLOW_FORM_FIELDS,
    ALLOW_SHAREPOINT,
    ALLOW_REVIEWER,
    ALLOW_ATTACHMENTS,
    ALLOW_INITIALS_FIELDS,
    ALLOW_INPERSON_FIELDS,
    ALLOW_INTEGRATION,
    ALLOW_PUBLISHING_DOCUMENT_HOSTORY,// - this feature is removed from serviceplan as it is handled under Integration
    ALLOW_BULK_SIGNING,
    SERVICE_PLAN_FEATURE_CLOUD_DRIVES,
    ALLOW_EDITOR,
    ALLOW_SEND_A_COPY,
}

public enum ServicePlanType
{
    INDIVIDUAL = 1,
    ENTERPRISE = 2,
    NONE = 3
}

public enum EmailTemplateNames
{
    ACCOUNT_ACTIVATION_COMPLETION,
    ACCOUNT_REGISTRATION,
    ACCOUNT_REMOVE,
    ENTERPRISE_ACCOUNT_REGISTRATION,
    ENTERPRISE_USER_ACCOUNT_REGISTRATION,
    PUBLISH_WORKFLOW_HISTORY_ON_COMPLETE,
    RESET_PASSWORD,
    WORKFLOW_COMPLETED,
    WORKFLOW_PROCESSED_DECLINED,
    WORKFLOW_PROCESSED_REVIEWED,
    WORKFLOW_RECALLED,
    WORKFLOW_SHARED,
    WORKFLOW_SHARED_REMINDER,
    WORKFLOW_UPDATED,
    WORKFLOW_POST_PROCESS,
    WORKFLOW_SIGNED,
    PASSWORD_RESET_COMPLETION,
    WORKFLOW_PROCESSED_ELECTRONIC_SIGNED,
    ENTERPRISE_INVITATION,
    WORKFLOW_PROCESSED_EDITED,
    MANUAL_POST_PROCESS,
    SEND_A_COPY_SENT,
    WORKFLOW_PROCESSED_BY_OTHERS,
    WORKFLOW_PROCESSED_BY_ME,
    EMAIL_ACTIVATION,
    EMAIL_FORGOT_PASSWORD,
    CREATE_PASSWORD_NON_SH_ID,
    ADMIN_RESET_PASSWORD,
    EMAIL_DOCUMENT_DELETION,
    EMAIL_DOCUMENT_DELETION_NOTIFICATION,
    PRODUCT_LICENSE_EXPIRY,
    EMAIL_BOUNCED,
    SUMMARY_EMAIL,
    WORKFLOW_ADD_COMMENT,
    INACTIVE_ACCOUNT_REMOVE,
    CERTIFICATE_REVOKED_OR_EXPIRED,
    CONSTRAINTS_QUOTA_CONSUMED,
    ACCOUNT_DOWNGRADED,
    ACCOUNT_REGISTERED,
    ENTERPRISE_RESET_PASSWORD,
    ENTERPRISE_PASSWORD_RESET_COMPLETION,
    ENTERPRISE_USER_REGISTRATION,
    ACCOUNT_RESET_PASSWORD,
    WORKSPACE_SHARED,
    BILLING_WORLDPAY_PAYMENT_SUCCESS,
    BILLING_WORLDPAY_PAYMENT_FAILED,
    BILLING_STRIPE_PAYMENT_SUCCESS,
    BILLING_STRIPE_PAYMENT_FAILED,
    SIGNATURE_QUOTA_CONSUMED_ALERT,
    OTP,
    ADMIN_ARCHIVING_SUCCESS,
    ADMIN_ARCHIVING_FAILURE,
    SIMPLE_ELECTRONIC_SIGNATURE_QUOTA_CONSUMED_ALERT
}

public enum AboutApplication
{
    ABOUT_US_PATENT_NO,
    ABOUT_ASCERTIA_ALL_RIGHTS_RESERVED
}

public enum SystemSettingAttribute
{
    /// <summary>
    /// Signing Service Profile ID for Sign workflow evidence report
    /// </summary>
    PROCESS_EVIDENCE_PROFILEID,

    /// <summary>
    /// ESeal Certification Profile to Sign Workflow Evidence Report
    /// </summary>
    PROCESS_EVIDENCE_ESEAL_CAPACITY,

    /// <summary>
    /// ADSS signing profile
    /// </summary>
    PROCESS_EVIDENCE_SIGNING_SERVER_PROFILE,

    /// <summary>
    /// Marginal days provided to a user when his service plan is expired
    /// </summary>
    BILLING_MARGIN_DAYS,

    /// <summary>
    /// License attribute, help in setting and getting License in XML format
    /// </summary>
    LICENSE,

    /// <summary>
    /// Installed application name
    /// </summary>
    APPLICATION_NAME,

    /// <summary>
    /// Installed application base url
    /// </summary>
    BASE_URL,

    /// <summary>
    /// Register button URL if over written
    /// </summary>
    REGISTER_PAGE_URL,

    /// <summary>
    /// Web Help page URL
    /// </summary>
    WEB_HELP_PAGE_URL,

    /// <summary>
    /// Admin Help page URL
    /// </summary>
    ADMIN_HELP_PAGE_URL,

    /// <summary>
    /// Error Notifications sent to this email address from Signinghub
    /// </summary>
    ERRORS_NOTIFICATION_EMAIL_TO,

    /// <summary>
    /// Error notification email subject that is sent from signinghub
    /// </summary>
    ERRORS_NOTIFICATION_EMAIL_SUBJECT,

    /// <summary>
    /// Email sending attempts,
    /// </summary>
    EMAIL_SENDING_ATTEMPTS,

    /// <summary>
    /// Email sending thread time out
    /// </summary>
    EMAIL_SENDING_TIMEOUT,

    /// <summary>
    /// Default contact us email address, All contact us links will lead to this email address
    /// </summary>
    CONTACT_US_EMAIL_TO,

    /// <summary>
    /// Marginal days provided to a user when his service plan is expired
    /// </summary>
    //DEFAULT_MARGIN_DAYS,
    /// <summary>
    /// Signinghub default language
    /// </summary>
    DEFAULT_LANGUAGE,

    /// <summary>
    /// Signinghub default theme folder name (default value = Default)
    /// </summary>
    DEFAULT_THEME,

    /// <summary>
    /// SESSION_TIMEOUT
    /// </summary>
    SESSION_TIMEOUT,

    /// <summary>
    /// Signinghub default currency (probably EURO)
    /// </summary>
    DEFAULT_CURRENCY,

    /// <summary>
    /// Signinghub default country (United Kingdom)
    /// </summary>
    DEFAULT_COUNTRY,

    /// <summary>
    /// Boolean value to restrict users from changing country
    /// </summary>
    ALLOW_COUNTRY_CHANGE,

    /// <summary>
    /// Signinghub default time zone
    /// </summary>
    DEFAULT_TIMEZONE,

    /// <summary>
    /// Boolean value to restrict users from changing time zones
    /// </summary>
    ALLOW_TIMEZONE_CHANGE,

    /// <summary>
    /// Allow password authentication
    /// </summary>
    ALLOW_PASSWORD_AUTHENTICATION,

    /// <summary>
    ///Allow  Terms of service
    /// </summary>
    ALLOW_API_AGREE_TERMS_OF_SERVICE,

    /// <summary>
    /// Admin url
    /// </summary>
    ADMIN_BASE_URL,

    /// <summary>
    /// Signinghub default SMTP connector
    /// </summary>
    DEFAULT_SMTP_CONNECTOR,

    /// <summary>
    /// Signinghub default Authentication mechanism, it should be opened on the frontend when first time borwsed
    /// </summary>
    DEFAULT_AUTHENTICATION_MECHANISM,

    /// <summary>
    /// Individual plan with least features and free
    /// </summary>
    DOWNGRADE_INDIVIDUAL_PLANS_TO,

    /// <summary>
    /// Enterprise plan with least features and free
    /// </summary>
    DOWNGRADE_ENTERPRISE_PLANS_TO,

    /// <summary>
    /// Billing is enabled for the deployment or not
    /// </summary>
    BILLING_ENABLED,

    /// <summary>
    /// Default payment gateway (usually WorldPay)
    /// </summary>
    DEFAULT_PAYMENT_GATEWAY_CONNECTOR,

    /// <summary>
    /// If VAT is enabled or not
    /// </summary>
    VAT_ENABLED,

    /// <summary>
    /// VAT percentage to add in the original price of the plan
    /// </summary>
    VAT_PERCENTAGE,

    /// <summary>
    /// Web service URL used for soft restart
    /// </summary>
    WEB_SERVICE_URL,

    /// <summary>
    /// Default Document location? May be not needed
    /// </summary>
    [Obsolete("")]
    DEFAULT_DOCUMENT_LOCATION,

    /// <summary>
    /// Default OTP connector, may be not needed.
    /// </summary>
    //[Obsolete]
    DEFAULT_OTP_CONNECTOR,

    /// <summary>
    /// Latest license installed on UTC 0 date
    /// </summary>
    LICENSE_INSTALLATION_DATE,

    /// <summary>
    /// Hashing algorithm? it is also taken in signing profile, may be needed for password encryption or document encrpytion
    /// </summary>
    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    //[Obsolete("Should be renamed to ENCRYPTION_HASHING_ALGORITHM", false)]
    HASH_ALGORITHM,

    /// <summary>
    /// Encryption vector is needed to initialize encryption may be?
    /// </summary>
    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    //[Obsolete("Should be renamed to ENCRYPTION_INIT_VECTOR", false)]
    INIT_VECTOR,

    /// <summary>
    /// Encryption key size, should be renamed to
    /// </summary>
    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    //[Obsolete("Should be renamed to ENCRYPTION_KEY_SIZE")]
    KEY_SIZE,

    /// <summary>
    /// Ecnryption pass phrase
    /// </summary>
    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    // [Obsolete("Should be renamed to ENCRYPTION_PASS_PHRASE", false)]
    PASS_PHRASE,

    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    // [Obsolete("Should be renamed to something meaningful", false)]
    PASSWORD_ITERATIONS,

    /// <summary>
    /// salt value for password hashing
    /// </summary>
    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    // [Obsolete("Should be renamed to ENCRYPTION_SALT_VALUE", false)]
    SALT_VALUE,

    /// <summary>
    /// Password policy character length
    /// </summary>
    PASSWORD_POLICY_MINIMUM_LENGTH,

    /// <summary>
    /// Password policy strictly enforce upper and lower characters
    /// </summary>
    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    // [Obsolete("Should be renamed to PASSWORD_POLICY_CHARACTER_UPPER_LOWER", false)]
    PASSWORD_POLICY_ENFORCE_UPPER_LOWER_CHARACTER,

    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    // [Obsolete("Should be renamed to PASSWORD_POLICY_ONE_NUMERIC", false)]
    PASSWORD_POLICY_ENFORCE_AT_LEAST_NUMBER,

    // We will have to provide a script for updating these keys - so i am commenting these line temporarily
    // [Obsolete("Should be renamed to PASSWORD_POLICY_CHARACTER_SPECIAL", false)]
    PASSWORD_POLICY_ENFORCE_AT_LEAST_ONE_SPECIAL_CHRACTER,

    //WEB_SERVICE_URL_INTERNAL,
    //BASE_URL_INTERNAL,
    PRIVACY_POLICY_URL,

    TERMS_OF_USE_URL,
    CORE_SERVICE_URL,
    CORE_SERVICE_URL_INTERNAL,
    APPLICATION_BUILD,
    DATABASE_VERSION,

    DEFAULT_AZURE_BLOB_CONNECTOR,

    //Added dropbox connector key
    DEFAULT_CLOUD_DRIVES_DROPBOX_CONNECTOR,

    //GoogleDrive connector key
    DEFAULT_CLOUD_DRIVES_GOOGLE_DRIVE_CONNECTOR,

    DEFAULT_CLOUD_DRIVES_GOOGLE_DRIVE_CONNECTOR_FOR_PUSH_DOCUMENT,

    ERRORS_NOTIFICATION_EMAIL_BODY,

    //OneDrive connector key
    DEFAULT_CLOUD_DRIVES_ONEDRIVE_CONNECTOR,

    //System logo
    DEFAULT_SYSTEM_LOGO,

    //Marketing HubSpot connector key
    DEFAULT_MARKETING_CONNECTOR,

    //Conversion rates of currencies
    CONVERSION_RATE_EUR_TO_GBP,

    CONVERSION_RATE_EUR_TO_USD,
    CONVERSION_RATE_GBP_TO_EUR,
    CONVERSION_RATE_GBP_TO_USD,
    CONVERSION_RATE_USD_TO_EUR,
    CONVERSION_RATE_USD_TO_GBP,

    /// <summary>
    /// Mobile app dynamic link
    /// </summary>
    MOBILE_APPS_URL,

    LICENSE_EXPIRY_ALERT_FIRST_DAYS,
    LICENSE_EXPIRY_ALERT_SECOND_DAYS,
    LICENSE_EXPIRY_ALERT_SEND_TO,
    LINK_EXPIRY_FORGOT_PASSWORD,
    LINK_EXPIRY_ACTIVATION_INVITATION,
    BULK_DOWNLOAD_MAX_SIZE,
    BULK_ACTION_MAX_COUNT,
    ANALYTICS_GOOGLE,
    ANALYTICS_BING,
    ANALYTICS_PIXEL,
    ANALYTICS_GOOGLE_MOBILE_WEB,
    ANALYTICS_BING_MOBILE_WEB,
    APP_INSIGHT_INSTRUMENTATION_KEY,

    /// <summary>
    /// Expiray of Refresh token for API
    /// </summary>
    WEB_SERVICE_REFRESH_TOKEN_EXPIRY_TIME,

    /// <summary>
    /// Expiry of Access Token for API
    /// </summary>
    WEB_SERVICE_ACCESS_TOKEN_EXPIRY_TIME,

    CORE_MANAGER_PORT,
    CORE_OFF_PEAK_TIME,
    CORE_AUTO_ARCHIVING_INTERVAL,
    CORE_AUTO_DELETION_INTERVAL,
    CORE_AUTO_DELETION_NOTIFICATIONS_INTERVAL,
    CORE_AUTO_DELETION_UNAUTHORIZED_TRANSACTIONS_INTERVAL,
    CORE_LICENSE_EXPIRY_INTERVAL,
    CORE_AUTO_REMINDER_INTERVAL,
    CORE_AUTO_DECLINE_INTERVAL,
    CORE_FAST_DELETION_INTERVAL,
    CORE_SUMMARY_EMAIL_INTERVAL,
    CORE_ACTIVE_DIRECTORY_CONTACTS_SYNCHRONIZER_INTERVAL,
    CORE_NOTIFICATIONS_DELETION_DURATION,
    CORE_EMAIL_FETCH_INTERVAL, CORE_EMAIL_RETRY_COUNT,
    CORE_FAILED_REQUEST_RETRY_COUNT,
    DEFAULT_GEO_IP_CONNECTOR,
    DEFAULT_PUSH_NOTIFICATION_CONNECTOR,
    DEFAULT_GOOGLE_CONNECTOR_CAPTCHA,

    MOBILE_WEB_URL,
    DATA_DIRECTORY,
    DATA_DIRECTORY_MODE,
    DATA_SECURITY,
    SIGNALR,
    DATA_SECURITY_DEFAULT_CONNECTOR,
    DEK,
    COMPANY_FAVICON_ICON,
    COMPANY_COPYRIGHTS,
    ALLOW_LANGUAGE_DROPDOWN,
    COMPANY_BILLING_ADDRESS,
    COMPANY_BILLING_SUPPORT_EMAIL,
    COMPANY_BILLING_SALES_EMAIL,
    REPORT_DOMAIN_NAME,
    LICENSE_EXPIRY_ALERT_DAYS,
    LICENSE_ALERT_SIGNATURE_CONSUMED_QUOTA,
    LICENSE_ALERT_SIMPLE_ELECTRONIC_SIGNATURE_CONSUMED_QUOTA,
    //For Installer
    DECRYPTION_KEY,

    VALIDATION_KEY,
    VALIDATION_ALGO,
    DECRYPTION_ALGO,
    CORE_BASE_URL,
    EMAIL_ATTACHMENT_SIZE,

    /// <summary>
    /// Enable/Disabe Core threads
    /// </summary>
    ///
    [StringValue("EmailRetry")]
    CORE_EMAIL_RETRY_THREAD,

    [StringValue("DeleteDocuments")]
    CORE_DELETE_DOCUMENTS_THREAD,

    [StringValue("SummaryEmail")]
    CORE_SUMMARY_EMAIL_THREAD,

    [StringValue("DocumentProcessing")]
    CORE_DOCUMENT_PROCESSING_THREAD,

    [StringValue("DailyThreads")]
    CORE_DAILY_THREAD,

    [StringValue("ReminderEmails")]
    CORE_REMINDER_THREAD,
    CORE_REMINDER_EMAIL_TIME,

    CORE_SYNC_AD_CONTACTS_THREAD,
    LOGIN_PAGE_URL,
    CONFIGURATIONS_SIGNALR_BACKPLANE_TYPE,
    CONFIGURATIONS_SIGNALR_REDIS_SERVER_ADDRESS,
    CONFIGURATIONS_SIGNALR_REDIS_SEVER_PORT,
    CONFIGURATIONS_SIGNALR_APP_NAME,
    CONFIGURATIONS_SIGNALR_APP_PASSWORD,
    CONFIGURATIONS_SIGNALR_EXTERNAL_SERVICE_CONNECTION_STRING,
    ALLOW_EMAIL_CERTIFICATE_REVOKED_OR_EXPIRED,
    ALLOW_ADD_NATIONAL_ID_NUMBER,

    /// <summary>
    /// Password policy enforce change password setting
    /// </summary>
    PASSWORD_POLICY_ENFORCE_CHANGE_PASSWORD,

    // Account Lock settings
    ACCOUNT_LOCKED_ENABLED,

    ACCOUNT_LOCKED_COUNT,
    ACCOUNT_LOCKED_DURATION,
    ALLOW_USER_REGISTRATION,

    // Password Expiry policy
    PASSWORD_POLICY_EXPIRY_ENABLED,

    PASSWORD_POLICY_EXPIRY_DURATION,

    /// <summary>
    /// Error Notifications TimeOut
    /// </summary>
    ERROR_NOTIFICATION_TIMEOUT,

    DOCUMENT_LOCK_ENABLED,
    DOCUMENT_LOCK_SIGNING_SERVER_PROFILE,
    DOCUMENT_LOCK_ESEAL_CAPACITY,
    FILE_SCANNING_CONNECTOR_DEFAULT,
    EMAILS_USE_RECIPIENT_LANGUAGE,
    PROCESS_EVIDENCE_IS_ENABLED,

    /// <summary>
    /// Default TSA Connector
    /// </summary>
    DEFAULT_TIMESTAMPING_CONNECTOR,

    CORE_RESET_USER_STATISTICS,

    CORE_DOWNGRADE_SERVICEPLAN,

    CORE_DELETE_ACTIVITY_LOGS_THREAD,
    CORE_DELETE_ACTIVITY_LOGS_DURATION,

    LOA_ELECTRONIC_SIGNATURE,
    LOA_ELECTRONIC_SEAL,
    LOA_ADVANCED_ELECTRONIC_SEAL,
    LOA_QUALIFIED_ELECTRONIC_SEAL,
    LOA_ADVANCED_ELECTRONIC_SIGNATURE,
    LOA_HIGH_TRUST_ADVANCED,
    LOA_QUALIFIED_ELECTRONIC_SIGNATURE,

    LOA_ELECTRONIC_SIGNATURE_ABB,
    LOA_ELECTRONIC_SEAL_ABB,
    LOA_ADVANCED_ELECTRONIC_SEAL_ABB,
    LOA_QUALIFIED_ELECTRONIC_SEAL_ABB,
    LOA_ADVANCED_ELECTRONIC_SIGNATURE_ABB,
    LOA_HIGH_TRUST_ADVANCED_ABB,
    LOA_QUALIFIED_ELECTRONIC_SIGNATURE_ABB,

    USER_SESSION_LIMIT,

    ARCHIVE_ENABLED,
    ARCHIVE_DATA_DIRECTORY,
    ARCHIVE_NOTIFICATION_EMAIL_TO,
    //ARCHIVE_ZIP_PASSWORD_ENABLED,
    //ARCHIVE_ZIP_PASSWORD,
    ARCHIVE_PERSONAL_EXCHANGE_FILE,
    ARCHIVE_PERSONAL_EXCHANGE_FILE_INFO,
    ARCHIVE_PFX_PASSWORD
}

public enum ConnectorPurpose
{
    AUTHENTICATION = 1,
    CERTIFICATION = 2,
    SIGNING = 3,
    VERIFICATION = 4,
    DOCUMENT_REPOSITORY = 5,
    SMS_GATEWAY_PURPOSE = 6,
    PAYMENT_GATEWAY = 7,
    SMTP_SERVER_PURPOSE = 8,
    CONNECTOR_PURPOSE_CLOUD_DRIVES_INTEGRATION = 9,
    MARKETING = 10,
    PUSH_NOTIFICATION = 11,
    GEOIP_LOCATION = 12,
    GOOGLE_CONNECTOR_CAPTCHA_PURPOSE = 13,
    FILE_SCANNING = 14,
    TIMESTAMPING = 15,
}

[JsonConverter(typeof(StringEnumConverter))]
public enum DocumentStatus
{
    ALL = 0,
    DRAFT = 1,
    INPROGRESS = 2,
    PENDING = 3,
    SIGNED = 4,
    COMPLETED = 5,
    REVIEWED = 6,
    DECLINED = 7,
    POSTPROCESS = 8,
    RECALLED = 9,
    ESIGNED = 10,
    PUBLISHDOCUMENTHISTORY = 11,
    REMINDER = 12,
    EDITED = 13,

    //Added for the time being but later it will be deleted BY SALMAN ZAFAR
    ARCHIVED = 15,

    EXPIRING_IN_SEVEN_DAYS = 16,
    ADD_COMMENT = 17
}

public enum DocumentActionStatus
{
    DISABLED = 0,
    ENABLED = 1,
    INPROGRESS = 2
}

public enum EnterpriseUserPersonalSettingsToSkip
{
    EMAIL_ON_ACCOUNT_DOWNGRADED,
    EMAIL_ON_TEMPLATES_LIMIT_REACHED,
    EMAIL_ON_WORKFLOW_LIMIT_REACHED,
    EMAIL_ON_SIGNATURE_LIMIT_REACHED,
    EMAIL_ON_SIMPLE_ELECTRONIC_SIGNATURE_LIMIT_REACHED,
    EMAIL_ON_USER_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_ACCOUNT_DOWNGRADE,
    NOTIFY_ON_SCREEN_SERVICE_PLAN_CHANGED,
    NOTIFY_ON_SCREEN_SERVICE_PLAN_RESET,
    NOTIFY_ON_SCREEN_TEMPLATE_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_USER_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_WORKFLOW_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_SIGNATURE_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_SIMPLE_ELECTRONIC_SIGNATURE_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_PAYMENT_ONLINE,
}

public enum ServicePlanQuotaLimitEmailContent
{
    CONSTRAINTS_QUOTA_CONSUMED_TEMPLATES,
    CONSTRAINTS_QUOTA_CONSUMED_WORKFLOWS,
    CONSTRAINTS_QUOTA_CONSUMED_USERS,
    CONSTRAINTS_QUOTA_CONSUMED_SIGNATURES,
    CONSTRAINTS_QUOTA_CONSUMED_SIMPLE_ELECTRONIC_SIGNATURES,
}

public enum AccountSettings
{
    #region Stats related

    CONSUMED_SIGNATURES,
    CONSUMED_TEMPLATES,
    TOTAL_CONSUMED_USERS,
    TOTAL_CONSUMED_SIGNATURES,
    TOTAL_CONSUMED_TEMPLATES,
    TOTAL_CONSUMED_DISK_SPACE,
    TOTAL_CONSUMED_WORKFLOWS,

    #endregion Stats related

    #region Signature settings related

    DEFAULT_SIGNING_REASON,

    SELECTED_SIGNING_REASON_OPTION,

    DIGITAL_SIGNATURE_META_INFO_CONTACT,

    DIGITAL_SIGNATURE_META_INFO_LOCATION,

    DEFAULT_HAND_SIGNATURE_OPTION_FOR_MOBILE,

    DIGITAL_SIGNATURE_UPLOAD_IMAGE_FOR_MOBILE,

    DIGITAL_SIGNATURE_TEXT_FOR_MOBILE,

    DEFAULT_HAND_SIGNATURE_OPTION_FOR_WEB,

    DIGITAL_SIGNATURE_UPLOAD_IMAGE_FOR_WEB,

    DIGITAL_SIGNATURE_TEXT_FOR_WEB,

    DEFAULT_SIGNATURE_APPEARANCE,

    SAVE_EACH_REVISION,

    XADES_SIGNATURE_COMMITMENT_TYPE_INDICATION,

    #region Initials related

    INITIALS_OPTION,
    INITIALS_UPLOAD,
    INITIALS_TEXT,

    #endregion Initials related

    #endregion Signature settings related

    #region Delegation related

    //DELEGATION_ENABLED,
    //DELEGATOR_ID,
    //DELEGATOR_NAME,
    //DELEGATION_VALID_FROM,
    //DELEGATION_VALID_TO,
    //This key is only used to transfer user preffered name from user to client side.
    DELEGATION_USER_PREFFERED_NAME,

    #endregion Delegation related

    #region Emails notification related

    EMAIL_ON_DOCUMENT_RECALLED,
    SETTINGS_EMAIL_NOTIFY_RECALL,
    EMAIL_ALL_RECIPIENTS_ON_DOCUMENT_RECALLED,
    NOTIFY_PENDING_RECIPIENTS_ON_RECALL,
    NOTIFY_All_RECIPIENTS_ON_RECALL,
    EMAIL_ON_DOCUMENT_SENT_OR_SIGNED,
    EMAIL_ON_DOCUMENT_SIGNED,
    EMAIL_ON_WORKFLOW_COMPLETED,
    EMAIL_ON_DOCUMENT_SUMMARY,
    EMAIL_ON_DOCUMENT_UPDATED_BY_OTHERS,
    EMAIL_ON_DOCUMENT_UPDATED_BY_ME,
    EMAIL_ON_PASSWORD_CHANGE,
    EMAIL_ON_ACCOUNT_DOWNGRADED,
    EMAIL_ON_TEMPLATES_LIMIT_REACHED,
    EMAIL_ON_WORKFLOW_LIMIT_REACHED,
    EMAIL_ON_SIGNATURE_LIMIT_REACHED,
    EMAIL_ON_SIMPLE_ELECTRONIC_SIGNATURE_LIMIT_REACHED,
    EMAIL_ON_USER_LIMIT_REACHED,
    ERROR_NOTIFICATION_TIMEOUT,

    #endregion Emails notification related

    #region Enterprise Related

    SHAREPOINT,

    PUBLISH_HISTORY_ALLOWED,
    PUBLISH_HISTORY_URL,
    PUBLISH_HISTORY_INCLUDE_COMPLETED_DOCUMENTS,

    PASSWORD_POLICY_ENABLE,
    PASSWORD_POLICY_MINIMUM_LENGTH,
    PASSWORD_POLICY_ENFORCE_UPPER_LOWER_CHARACTER,
    PASSWORD_POLICY_ENFORCE_AT_LEAST_NUMBER,
    PASSWORD_POLICY_ENFORCE_AT_LEAST_ONE_SPECIAL_CHRACTER,

    PASSWORD_POLICY_EXPIRY_ENABLED,
    PASSWORD_POLICY_EXPIRY_DURATION,

    DEFAULT_COMPANY_LOGO,
    LOGIN_PAGE_URL,
    DOCUMENT_PROCESSING_CALLBACK_URL,
    DEFAULT_ROLE_FOR_GUEST_USER,

    #endregion Enterprise Related

    #region Document Certify Related for Enterprise Settings

    DEFAULT_CERTIFY_DOCUMENT,
    DEFAULT_LOCK_DOCUMENT_ON_COMPLETION,

    #endregion Document Certify Related for Enterprise Settings

    #region Collaborator Persmissions for Enterprise Settings

    DEFAULT_ALLOW_PRINT,
    DEFAULT_ALLOW_DOWNLOAD,
    DEFAULT_ALLOW_ON_PAGE_COMMENTING,
    DEFAULT_ALLOW_ADD_ATTACHMENT,
    DEFAULT_ALLOW_CHANGE_SIGNER,
    DEFAULT_LEGAL_NOTICE,
    DEFAULT_SET_LEGAL_NOTICE,
    DEFAULT_FIRST_REMINDER,
    DEFAULT_FIRST_REMINDER_DURATION,
    DEFAULT_REPEAT_REMINDER,
    DEFAULT_REPEAT_REMINDER_DURATION,
    DEFAULT_REPEAT_REMINDER_COUNT,

    #endregion Collaborator Persmissions for Enterprise Settings

    #region Billing Related

    AUTO_RECHARGE,

    #endregion Billing Related

    #region Account Related

    USER_LANGUAGE,

    #endregion Account Related

    #region Cloud Drive

    GOOGLE_DRIVE_AUTHENTICATION_TOKEN,
    DROPBOX_AUTHENTICATION_TOKEN,
    ONEDRIVE_AUTHENTICATION_TOKEN,

    #endregion Cloud Drive

    #region Document Unlocking

    UNLOCK_DOCUMENT_ON_COMPLETION,

    #endregion Document Unlocking

    SERVICE_PLAN_AUTO_RESET_ON,
    SKIP_LOGIN_FOR_DSIGN,
    DEFAULT_ROLE_INTEGRATION,

    //DOCUMENTS_UPLOADED,
    //DOCUMENT_REPOSITORY_SHAREPOINT_USERNAME,
    //DOCUMENT_REPOSITORY_SHAREPOINT_PASSWORD,
    //SIGNING_REASON,

    #region Web notification related

    NOTIFY_ON_SCREEN_DOCUMENT_RECALLED,
    NOTIFY_ON_SCREEN_DOCUMENT_SENT_OR_SIGNED,
    NOTIFY_ON_SCREEN_WORKFLOW_COMPLETED,
    NOTIFY_ON_SCREEN_DOCUMENT_UPDATED_BY_OTHERS,
    NOTIFY_ON_SCREEN_PAYMENT_ONLINE,
    NOTIFY_ON_SCREEN_SERVICE_PLAN_RESET,
    NOTIFY_ON_SCREEN_TEMPLATE_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_WORKFLOW_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_SIGNATURE_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_SIMPLE_ELECTRONIC_SIGNATURE_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_USER_LIMIT_REACHED,
    NOTIFY_ON_SCREEN_SERVICE_PLAN_CHANGED,
    NOTIFY_ON_SCREEN_FORGOT_PASSWORD,
    NOTIFY_ON_SCREEN_CHANGE_PASSWORD,
    NOTIFY_ON_SCREEN_LOGIN_FAILED,
    NOTIFY_ON_SCREEN_ACCOUNT_UPGRADE,
    NOTIFY_ON_SCREEN_ACCOUNT_DOWNGRADE,
    NOTIFY_ON_SCREEN_DOCUMENT_UPDATED,

    #endregion Web notification related

    #region Push notification related

    PUSH_NOTIFY_ON_DOCUMENT_UPDATED,
    PUSH_NOTIFY_ON_WORKFLOW_COMPLETED,
    PUSH_NOTIFY_ON_DOCUMENT_SENT_OR_SIGNED,
    PUSH_NOTIFY_ON_SCREEN_DOCUMENT_UPDATED_BY_OTHERS,

    WEB_SERVER_CERTIFICATION_PROFILE_DEFAULT,

    #endregion Push notification related

    MOBILE_SERVER_CERTIFICATION_PROFILE_DEFAULT,
    AUTO_TRIGGER_AUTH_PROFILE,
    ALLOW_LOCATION_DETECTION,
    WITNESS_REASON,
    SIGNATURE_FONT,
    //NOTIFICATION_EMAILS_RIGHT_TO_LEFT,
    SIGNATURE_LEVEL_OF_ASSURANCE,
    LEVEL_OF_ASSURANCE_DEFAULT,
    PASSWORD_POLICY_ENFORCE_CHANGE_PASSWORD,
    SIGNING_REASON,
    DOWNLOAD_ALLOWED_ONLY_IN,
    //GATEKEEPER_ENABLED,
    //GATEKEEPER_ID,
    GATEKEEPER_NAME,
    GATEKEEPER_USER_PREFFERED_NAME,
    ALLOW_ADD_UNIQUE_IDENTIFIER,
    DEFAULT_DOCUMENT_ATTACHMENT_REQUIRED,
    DEFAULT_DOCUMENT_ATTACHMENT_REQUIRED_NOTE
}

public enum SettingsType
{
    DELEGATION,
    APPEARANCE,
    SIGNATURE,
    CLOUD_DRIVE
}

public enum CollaboratorType
{
    GROUP,
    CONTACT
}

[JsonConverter(typeof(StringEnumConverter))]
public enum CollaboratorRole
{
    [StringValue("Signer")]
    SIGNER = 0,

    [StringValue("Reviewer")]
    REVIEWER = 1,

    [StringValue("Editor")]
    EDITOR = 2,

    [StringValue("Meeting Host")]
    INPERSON_HOST = 3,

    [StringValue("PlaceHolder")]
    PLACEHOLDER = 4,

    [StringValue("Send a Copy")]
    CARBON_COPY = 5
}

public enum CollaboratorSubTaskType
{
    INITIAL = 0,
    INPERSON = 1,
    FORM_FIELD = 2,
    HAND_SIGNATURE = 3
}

public enum FieldType
{
    ASSIGNED = 0,
    UN_ASSIGNED = 1,
    SIGNED = 2,
    LOGGED_IN_USER = 3,
    HIDDEN = 4,
    PLACEHOLDER = 6,
    GENERALTASK = 7,
}

public enum TaskProcessStatus
{
    UN_PROCESSED = 0,
    SIGNED = 1,
    REVIEWED = 2,
    DECLINED = 3,
    INVALID = 4,
    EDITED = 5,
    CARBON_COPIED = 7,
}

public enum SignatureType
{
    DIGITAL = 0,
    E_SIGNATURE = 1,
    ALL = 2
}

public enum FieldInputType
{
    NAME,
    EMAIL,
    JOBTITLE,
    COMPANY,
    DATE,
    TEXT,
    TEXTAREA,
    QRCODE,
    UNIQUE_IDENTIFIER
}

public enum CertifyPolicy
{
    NOT_CERTIFIED,
    NO_CHANGES_ALLOWED,
    FORM_FILLING_ALLOWED,
    FORM_FILLING_WITH_ANNOTATIONS_ALLOWED
}

public enum WorkFlowType
{
    [StringValue("Serial Workflow (Each recipient can only sign the document on his turn in a defined order)")]
    CENTRAL_SHARE = 0,

    [StringValue("Individual Workflow (Each recipient receives his copy of document and can sign it)")]
    INDIVIDUAL_SHARE = 1,

    [StringValue("Parallel Workflow (Each recipient receives the document immediately after sharing and can sign in any order)")]
    PARALLEL_SHARE = 2,

    [StringValue("Custom Workflow (Enables document owner to create a mixed workflow keeping some recipients in serial workflow and some in parallel)")]
    CUSTOM_SHARE = 3
}

public enum WorkflowStatus
{
    DRAFT = 0,
    SHARED = 1,
    COMPLETED = 2,
    DECLINED = 3,
    Terminated = 4
}

public enum AccountStatus
{
    UPDATED = 0,
    ARCHIVED = 1
}

public enum WebHooksUserAction
{
    CREATED,
    UPDATED,
    DELETED
}

public enum DefaultFolerNames
{
    INBOX,
    ARCHIVE
}

public enum BusinessType
{
    PERSONAL = 1,
    BUSINESS = 2
}

public enum RoleSettings
{
    #region HandSignatureSettingForWeb

    HAND_SIGNATURE_DRAW_FOR_WEB,
    HAND_SIGNATURE_UPLOAD_FOR_WEB,
    HAND_SIGNATURE_TEXT_FOR_WEB,
    DEFAULT_HAND_SIGNATURE_OPTION_FOR_WEB,
    DISABLE_HAND_SIGNATURE_TEXT_FOR_WEB,

    #endregion HandSignatureSettingForWeb

    #region HandSignatureSettingForMobile

    HAND_SIGNATURE_DRAW_FOR_MOBILE,
    HAND_SIGNATURE_UPLOAD_FOR_MOBILE,
    HAND_SIGNATURE_TEXT_FOR_MOBILE,
    DEFAULT_HAND_SIGNATURE_OPTION_FOR_MOBILE,
    DISABLE_HAND_SIGNATURE_TEXT_FOR_MOBILE,

    #endregion HandSignatureSettingForMobile

    #region Initials settings

    INITIALS_DRAW,
    INITIALS_TEXT,
    INITIALS_UPLOAD,
    INITIALS_OPTION,
    DISABLE_INITIALS_TEXT,

    #endregion Initials settings

    #region SignatureAppearanceSetting

    //SIGNATURE_APPEARANCE_ALL,
    //SIGNATURE_APPEARANCE_ONLY,
    DEFAULT_SIGNATURE_APPEARANCE,

    SIGNATURE_APPEARANCE_ALLOW_CHANGE,

    #endregion SignatureAppearanceSetting

    #region Signing Reasons

    SELECTED_SIGNING_REASON_OPTION,
    DEFAULT_SIGNING_REASON,

    #endregion Signing Reasons

    #region RoleEnterpriseSetting

    MANAGE_PROFILE,
    MANAGE_USER,
    MANAGE_ROLES,
    MANAGE_GROUP,
    MANAGE_DOCUMENT,
    MANAGE_TEMPLATE,
    MANAGE_LIBRARY,
    MANAGE_NOTIFICATIONS,
    MANAGE_INTEGRATION,
    MANAGE_ADVANCED,
    MANAGE_REPORT,
    MANAGE_BILLING,
    MANAGE_SIGNING_REASON,
    MANAGE_CLOUD_DRIVE,
    MANAGE_BRANDING,

    #endregion RoleEnterpriseSetting

    #region PersonalUserSettings

    MANAGE_PERSONAL_NOTIFICATIONS,
    MANAGE_PERSONAL_SIGNATURE,
    MANAGE_PERSONAL_GROUPS,
    MANAGE_PERSONAL_TEMPLATES,
    MANAGE_PERSONAL_LIBRARY,
    MANAGE_PERSONAL_ADVANCE,
    MANAGE_PERSONAL_LEGAL_NOTICES,
    MANAGE_PERSONAL_DELEGATES,
    MANAGE_PERSONAL_UPLPAD_AND_SHARE,
    MANAGE_START_FROM_EXISTING_WORKFLOW,
    MANAGE_PERSONAL_SHARE_WITH_ENTERPRISE_CONTACTS_AND_GROUPS,
    MANAGE_SCOPE_USER_UPLOAD_AND_SHARE,
    MANAGE_PERSONAL_DELEGATE_SIGNING_TO_REGISTERED_USERS,

    #endregion PersonalUserSettings

    #region Authentication mechanism for server side signing in Web

    WEB_SERVER_USERPWD_PRIMARY_AUTHENTICATION,
    WEB_SERVER_USERPWD_SECONDARY_AUTHENTICATION,
    WEB_SERVER_NOPWD_PRIMARY_AUTHENTICATION,
    WEB_SERVER_NOPWD_SECONDARY_AUTHENTICATION,

    MOBILE_SERVER_SYSGENERATED_PRIMARY_AUTHENTICATION,
    MOBILE_SERVER_SYSGENERATED_SECONDARY_AUTHENTICATION,

    MOBILE_SERVER_NOPWD_PRIMARY_AUTHENTICATION,
    MOBILE_SERVER_NOPWD_SECONDARY_AUTHENTICATION,

    #endregion Authentication mechanism for server side signing in Web

    #region Authentication mechanism for server side signing in Native Apps

    MOBILE_SERVER_USERPWD_PRIMARY_AUTHENTICATION,
    MOBILE_SERVER_USERPWD_SECONDARY_AUTHENTICATION,
    ROLE_ENABLE_OTP_ON_LOGIN,
    PRIMARY_AUTHENTICATION_FOR_LOGIN,
    ALLOW_PUBLIC_AUTHENTICATION_SCHEMES,
    ALLOW_BULKSIGN,
    ALLOW_AUTO_FINISH,

    MOBILE_SERVER_AES_CERTIFICATION_PROFILE,
    MOBILE_SERVER_CERTIFICATION_PROFILE_DEFAULT,

    #endregion Authentication mechanism for server side signing in Native Apps

    WEB_SERVER_AES_ENABLED,
    CERTIFICATION_PROFILE_WEB,
    WEB_SERVER_AES_CERTIFICATION_PROFILE,
    WITNESS_SIGN_PROFILE,

    //ESEAL
    WEB_SERVER_ESEAL_ENABLED,

    WEB_SERVER_ESEAL_CERTIFICATION_PROFILE,
    //Advanced ESEAL
    WEB_SERVER_ADVANCED_ESEAL_ENABLED,

    WEB_SERVER_ADVANCED_ESEAL_CERTIFICATION_PROFILE,
    //Qualified ESEAL
    WEB_SERVER_QUALIFIED_ESEAL_ENABLED,

    WEB_SERVER_QUALIFIED_ESEAL_CERTIFICATION_PROFILE,

    //AATL
    WEB_SERVER_AATL_ENABLED,

    WEB_SERVER_AATL_CERTIFICATION_PROFILE,

    //QES
    WEB_SERVER_QES_ENABLED,

    WEB_SERVER_QES_CERTIFICATION_PROFILE,

    WEB_SERVER_CERTIFICATION_PROFILE_DEFAULT,
    WEB_LOCAL_SIGNATURE_APPEARANCE,
    WEB_SERVER_SIGNATURE_APPEARANCE,

    ROLE_SHOW_REASON,

    ROLE_SHOW_CONTACT_INFO,
    ROLE_ALLOW_USER_TO_SKIP_SIGNING_DIALOG,
    ROLE_SHOW_LOCATION,
    MANAGE_ENTERPRISE_DOCUMENTS,
    ALLOW_INVISIBLE_SIGNATURE,
    WORKFLOW_MODE,
    WORKFLOW_TYPE,
    ALLOW_USER_TO_DELETE_DOCUMENT,
    ALLOW_OWNER_TO_RECALL_DOCUMENT,
    ALLOW_TO_CHANGE_RECIPIENT,
    MANAGE_ENTERPRISE_LOGS,
    ALLOW_TO_MANAGE_SHARED_SPACES,
    ALLOW_SIGNING,

    #region Document Settings

    ALLOW_OWNER_PRINT_DOCUMENT,
    ALLOW_OWNER_DOWNLOAD_DOCUMENT,
    ALLOW_OWNER_ATTACHMENTS_AND_MERGING,
    ALLOW_OWNER_VIEW_WORKFLOW_HISTORY,
    ALLOW_OWNER_DOCUMENT_SAVE_AS_TEMPLATE,
    ALLOW_ADD_COMMENTS,

    #region SignatureFields

    ALLOW_OWNER_ADD_DSIGN,
    SIGNATURE_LEVEL_OF_ASSURANCE,
    LEVEL_OF_ASSURANCE_DEFAULT,
    ALLOW_OWNER_ADD_INPERSON,
    ALLOW_OWNER_ADD_INITIAL,

    #endregion SignatureFields

    #region FormFields

    ALLOW_OWNER_ADD_NAME_FIELD,
    ALLOW_OWNER_ADD_EMAIL_FIELD,
    ALLOW_OWNER_ADD_JOB_TITLE_FIELD,
    ALLOW_OWNER_ADD_COMPANY_FIELD,
    ALLOW_OWNER_ADD_DATE_FIELD,
    ALLOW_OWNER_ADD_TEXT_FIELD,
    ALLOW_OWNER_ADD_TEXT_AREA,
    ALLOW_OWNER_ADD_RADIO_BUTTON_FIELD,
    ALLOW_OWNER_ADD_QR_FIELD,
    ALLOW_OWNER_ADD_CHECK_BOX_FIELD,
    ALLOW_OWNER_ADD_TEXT,

    #endregion FormFields

    #endregion Document Settings

    //signature fonts
    FONT_DEFAULT,

    ALLOW_MANAGE_SIGNATURE_LOGO,
    WEB_SERVER_SIGNING_SERVER,
    MOBILE_SERVER_SIGNING_SERVER,
    MOBILE_SERVER_AES_ENABLED,
    WEB_LOCAL_SIGNING_SERVER,

    SERVER_SIGNING_SERVER,

    WEB_SERVER_SYSGENERATED_PRIMARY_AUTHENTICATION,
    WEB_SERVER_SYSGENERATED_SECONDARY_AUTHENTICATION,
    LOCATION_DEFAULT
}

public enum RoleAllowedPermissions
{
    View,
    Add,
    Edit,
    Delete
}

public enum CollabortaorAction
{
    Add,
    Edit,
    Delete,
    UpdateOrder,
    UpdateType
}

public enum CollaboratorReminder
{
    REMINDER_DATE,
    FIRST_REMINDER, // On/Off
    FIRST_REMINDER_DURATION, // X days

    REPEAT_REMINDER, // On/Off
    REPEAT_REMINDER_DURATION, //X DAYS
    REPEAT_REMINDER_COUNT, // Y
    OTP_VALUE,
    OTP_EXPIRES_ON,

    //To ignore enum conversions
    EMAIL_LANGUAGE,

    //To store OTP sent to
    OTP_SENT_TO,
    ATTACHMENT_NAME
}

public enum CollaboratorDetailAttribute
{
    EMAIL_LANGUAGE,
    ATTACHMENT_NAME
}

public enum CollaboratorPermission
{
    CERTIFY_DOCUMENT,
    CERTIFY_DOCUMENT_POLICY,
    ALLOW_PRINT,

    ALLOW_DOWNLOAD,
    SET_DOCUMENT_ACCESS_PASSWORD,
    DOCUMENT_ACCESS_PASSWORD,
    SET_DOCUMENT_ACCESS_DURATION,
    DOCUMENT_ACCESS_DURATION_FROM,
    DOCUMENT_ACCESS_DURATION_TO,
    ALLOW_ON_PAGE_COMMENTING,
    SET_SIGNATURE_POLICY,
    SIGNATURE_POLICY,
    SET_REQUIRED_COMMITMENT_TYPE,
    COMMITMENT_TYPE,
    SET_DOCUMENT_RETENTATION_POLICY,
    DOCUMENT_RETENTATION_POLICY,
    SET_LEGAL_NOTICE,
    LEGAL_NOTICE,
    SET_DOCUMENT_ACCESS_NUMBER_FOR_OTP,
    DOCUMENT_ACCESS_NUMBER_FOR_OTP,
    DOCUMENT_ACCESS_OTP,
    ALLOW_ADD_ATTACHMENT,
    ALLOW_CHANGE_SIGNER,
    DOCUMENT_ACCESS_DURATION_VIA_DAYS,
    DOCUMENT_SIGNING_OTP_ENABLED,
    OTP_EXPIRES_ON,

    //To store otp sent to
    OTP_SENT_TO,

    DOCUMENT_ATTACHMENT_REQUIRED,
    DOCUMENT_ATTACHMENT_REQUIRED_NOTE
}

public enum UserType
{
    INVITED = 0,
    REGISTERED = 1,
    ACTIVATED = 2,
    BANNED = 3,
    MARK_DELETED = 4,
    GUEST = 5,
    IN_ACTIVE = 6,
    ARCHIVED = 7
}

public enum ChangePasswordType
{
    NONE = 0,
    RESET_BY_SETTING = 1,
    RESET_BY_ADMIN = 2
}

public enum Folders
{
    INBOX,
    ARCHIVE
}

public enum Status
{
    ENABLED = 1,
    DISABLED = 0,
    REMOVED = 2
}

public enum ProcessedAs
{
    COLLABORATOR,
    REVIEWER,
    DELEGATOR,
    GATEKEEPER,

    [StringValue("GROUP MEMBER")]
    GROUP_MEMBER,

    OWNER,
    Editor,
    SYSTEM
}

public enum SortOrder
{
    ASC = 0,
    DESC = 1
}

public enum DOCUMENTSOURCE
{
    FILE_SYSTEM,
    LIBRARY,
    SHAREPOINT,
    SALES_FORCE,
    DROPBOX,
    MS_OFFICE,
    GOOGLE_DRIVE,
    ONEDRIVE
}

[JsonConverter(typeof(StringEnumConverter))]
public enum HandSigntureMethods
{
    DRAW,
    UPLOAD,
    TEXT
}

public enum HomeFilterColumn
{
    Name,
    Owner,
    Size,
    LastModifiedOn,
    NextSigner,
}

public enum DocumentFieldValidation
{
    MAXIMUM_LENGTH,
    INPUT_TYPE,
    IS_REQUIRED,
    PLACEHOLDER,
    IS_FORMAT_FIXED,

    [StringValue("GroupName")]
    GROUP_NAME,

    USER_DEFINED_FONT_SIZE,
    FIELD_INPUT_TYPE,
    MULTI_LINE,
    VALIDATION_TYPE,
    VALIDATION_VALUE,
    FIELD_GUID_VALUE
}

public enum FormFieldValidationType
{
    EQUALS
}

public enum DefaultDocumentPackageName
{
    UNTITLED,
}

public enum FontAttributes
{
    FONT_FAMILY,
    FONT_SIZE,
    USER_DEFINED_FONT_SIZE,
    DATE_FORMAT,
}

public enum SubTaskRequired
{
    OPTIONAL = 0,
    MANDATORY = 1,
}

public enum SubTaskProcessStatus
{
    UN_PROCESSED = 0,
    PROCESSED = 1
}

public enum DocumentExtension
{
    PDF,
    DOCX,
    XML
}

public enum DocumentType
{
    ALL,
    PDF,
    DOCX,
    WORD,
    ZIP
}

public enum EmailStatus
{
    PENDING = 0,
    SENT = 1,
    FAILED = 2
}

public enum SigningAuthentication
{
    No,
    OTP,
    Login,
    PASSWORD,
}

public enum HandSignature
{
    DRAW,
    TEXT,
    UPLOAD,
    NONE //added for invisible signatures
}

public enum IsWitnessSignature
{
    ENABLED = 1,
    DISABLED = 0
}

public enum SignatureSubType
{
    WITNESS = 1
}

public enum SigningReasonOption
{
    CUSTOM = 0,
    PRE_DEFINED = 1,
    FIXED = 2
}

public enum ADSSModule
{
    ADSS_AUTHENTICATION,
    HOST_URL,
    REMOTE_ADDRESS,
    PROFILE_ID,
    ORIGINATOR_ID,
    CERTIFICATION_PROFILE_ID,
    SSL_CLIENT_CERTIFICATE_LOCATION,
    HASHING_ALGORITHM,
    VERIFICATION_PROFILE_ID,
    ADSS_GOSIGN_PROFILE_ID,
    TIMEOUT,
    SSL_CLIENT_CERTIFICATE,
    SSL_CLIENT_CERTIFICATE_FILE_INFO,
    SSL_CLIENT_CERTIFICATE_PASSWORD
}

public enum RequestType
{
    CERTIFICATE,
    SIGNING,
    VERIFICATION,
    HTTP,
    REST
}

public enum DocumentOverallStatus
{
    TRUSTED,
    UN_TRUSTED,
}

public enum SSLCertificateOvertAllStatus
{
    TRUSTED,
    UN_TRUSTED,
}

public enum UserCertificateType
{
    USER = 1,
    SYSTEM_GENERATED = 2,
    RAS = 3
}

public enum FolderItemStatus
{
    DRAFT = 1,
    INPROGRESS = 2,
    PENDING = 3,
    SIGNED = 4,
    COMPLETED = 5,
    REVIEWED = 6,
    DECLINED = 7,
    EDITED = 13,
}

public enum CollaboratorProcessStatus
{
    UN_PROCESSED = 0,
    IN_PROGRESS = 1,
    SIGNED = 2,
    REVIEWED = 3,
    DECLINED = 4,
    EDITED = 5,
    INVALID = 6,

    [StringValue("SENT A COPY")]
    CARBON_COPIED = 7

    //PROCESSED = 2,
}

public enum DocumentCertify
{
    NOT_CERTIFIED = 0,
    FORM_FILLING_WITH_ANNOTATIONS_ALLOWED = 3,
    FORM_FILLING_ALLOWED = 2,
    NO_CHANGES_ALLOWED = 1,
}

public enum ConnectorProvider
{
    SMS_GATEWAY,
    CONNECTION_PROVIDER_TWILLIO_SMS_GATEWAY,
    FIREBASE,
    T1C_SIGNING,
    FILE_SCANNING_ICAP
}

public enum IntegrationType
{
    ELECTRONIC,
    DIGITAL,
    INEGRATION,
    NORMAL,
}

public enum OtpConstraints
{
    OWNER_OTP_LENGTH,
    OWNER_OTP_RETRY_TIME,
    OWNER_OTP_EXPIRY_TIME,
    OWNER_OTP_SEND_EMAIL
}

public enum FontNames
{
    [StringValue("Times-Roman")]
    TIMES_ROMAN,

    [StringValue("Courier")]
    COURIER,

    [StringValue("Helvetica")]
    HELVETICA,

    [StringValue("CourierPrimeCode-Regular")]
    COURIER_FAMILY_NAME
}

public enum SystemFontNames
{
    [Description("Times New Roman")]
    TIMES_NEW_ROMAN,

    [Description("Courier New")]
    COURIER_NEW,
}

public enum AuthorizedRequestStatus
{
    PENDING = 1,
    AUTHORIZED = 2,
    SIGNED = 3,
    DECLINED = 4,
    SUCCESS = 5,
    CANCELLED = 6,
    FAILED = 7,
    EXPIRED = 8
}

public enum DefaultDateFormats
{
    [StringValue("dd/mm/yy")]
    UK_DATE_FORMAT,

    [StringValue("mm/dd/yyyy")]
    US_DATE_FORMAT,
}

public enum DateFormats
{
    [StringValue("yyyy-MM-dd")]
    ISO_8601_DATE_FORMAT
}

public enum UnitedStatesCountry
{
    [StringValue("united states")]
    UNITED_STATES,
}

public enum FieldFormatType
{
    [StringValue("date")]
    DATE,

    [StringValue("time")]
    TIME,

    [StringValue("datetime")]
    DATETIME
}

public enum DocumentImageScale
{
    NORMAL = 1,
    TWICE = 2
}

public enum FIREBASEConnectorDetail
{
    FIREBASE_CONNECTOR_PARAM_SERVER_KEY,
    FIREBASE_CONNECTOR_PARAM_SENDER_ID
}

public enum UserSource
{
    Enterprise,
    SigningHub,
    ActiveDirectory
}

public enum SystemLogActions
{
    WORLDPAY_BUYING,
    WORLDPAY_AGREEMENT_TERMINATED,
    WORLDPAY_RECURRENT_PAYMENT,
    WORLDPAY_PAYMENT,
    WORLDPAY_RECURRENT_PAYMENT_FAILURE,
    WORLDPAY_PAYMENT_FAILURE
}

public enum SystemLogInfoKeys
{
    WORLDPAY_FUTUREPAY_ID,
    WORLDPAY_TRANSACTION_ID,
    STRIPE_CUSTOMER_ID
}

public enum WorldPayConstanst
{
    [StringValue("rawAuthMessage")]
    RAW_AUTH_MESSAGE,

    [StringValue("cardbe.msg.authorised")]
    CARD_AUTHORISED,

    [StringValue("Authorised")]
    AUTHORISED,

    [StringValue("trans.cancelled")]
    TRANS_CANCELLED,

    [StringValue("transStatus")]
    TransStatus,

    [StringValue("futurePayId")]
    FuturePayId,

    [StringValue("authCurrency")]
    AuthCurrency,

    [StringValue("currency")]
    CURRENCY,

    [StringValue("authAmount")]
    AuthAmount,

    [StringValue("amount")]
    AMOUNT,

    [StringValue("transId")]
    WPTransId,

    [StringValue("authAmountString")]
    AuthAmountString,

    [StringValue("futurePayStatusChange")]
    FuturePayStatusChange,

    [StringValue("MC_FirstPayment")]
    MC_FirstPayment,

    [StringValue("MC_BILLING_DESCRIPTION")]
    MC_BILLING_DESCRIPTION,

    [StringValue("MC_SERVICEPLAN_ID")]
    MC_SERVICEPLAN_ID,

    [StringValue("address")]
    ADDRESS,

    [StringValue("tel")]
    PHONE,

    [StringValue("fax")]
    FAX,

    [StringValue("postcode")]
    POST_CODE,

    [StringValue("MC_SERVICEPLAN_PAYMENTTYPE")]
    MC_SERVICEPLAN_PAYMENTTYPE,

    [StringValue("MC_SERVICEPLAN_PRICE")]
    MC_SERVICEPLAN_PRICE,

    [StringValue("MC_BILLING_VATAMOUNT")]
    MC_BILLING_VATAMOUNT,

    [StringValue("MC_BILLING_VATNUMBER")]
    MC_BILLING_VATNUMBER,

    [StringValue("MC_BILLING_SELECTEDPAYMENTMODE")]
    MC_BILLING_SELECTEDPAYMENTMODE,

    [StringValue("desc")]
    DESCRIPTION,

    [StringValue("Y,Agreement cancelled")]
    AGREEMENT_CANCELLED,

    [StringValue("E,Agreement already finished")]
    AGREEMENT_ALREADY_CANCELLED,

    [StringValue("email")]
    USER_EMAIL,

    [StringValue("E,Agreement already finished")]
    AGREEMENT_ALREADY_FINISHED,

    [StringValue("MC_TRANSACTION_TYPE")]
    MC_TRANSACTION_TYPE,

    [StringValue("MC_USER_EMAILADDRESS")]
    MC_USER_EMAILADDRESS,

    [StringValue("MC_USER_NAME")]
    MC_USER_NAME,

    [StringValue("MC_USER_COMPANYNAME")]
    MC_USER_COMPANYNAME,

    [StringValue("MC_USER_MOBILENUMBER")]
    MC_USER_MOBILENUMBER,

    [StringValue("MC_USER_BUISNESSTYPE")]
    MC_USER_BUISNESSTYPE,

    [StringValue("MC_USER_JOBTITLE")]
    MC_USER_JOBTITLE,

    [StringValue("MC_USER_SOURCE")]
    MC_USER_SOURCE,

    [StringValue("MC_USER_ENTERPRISENAME")]
    MC_USER_ENTERPRISENAME,

    [StringValue("MC_USER_LANGUAGE")]
    MC_USER_LANGUAGE,

    [StringValue("MC_SERVICEPLAN_NAME")]
    MC_SERVICEPLAN_NAME,

    [StringValue("MC_IP_ADDRESS")]
    MC_IP_ADDRESS,

    [StringValue("MC_USER_AGENT_INFORMATION")]
    MC_USER_AGENT_INFORMATION,

    [StringValue("MC_ACTION_PERFORMED_BY")]
    MC_ACTION_PERFORMED_BY,

    [StringValue("CONNECTOR_NAME")]
    CONNECTOR_NAME,

    [StringValue("MC_BILLING_CONNECTOR_NAME")]
    MC_BILLING_CONNECTOR_NAME,

    [StringValue("BILLING_DESCRIPTION")]
    BILLING_DESCRIPTION,

    [StringValue("instId")]
    INSTID,

    [StringValue("cartId")]
    CARTID,

    [StringValue("option")]
    OPTION,

    [StringValue("testMode")]
    TESTMODE,

    [StringValue("noOfPayments")]
    NOOFPAYMENTS,

    [StringValue("futurePayType")]
    FUTUREPAYTYPE,

    [StringValue("startDelayUnit")]
    STARTDELAYUNIT,

    [StringValue("intervalUnit")]
    INTERVALUNIT,

    [StringValue("amountLimit")]
    AMOUNTLIMIT,

    [StringValue("startDelayMult")]
    STARTDELAYMULT,

    [StringValue("intervalMult")]
    INTERVALMULT,

    [StringValue("normalAmount")]
    NORMALAMOUNT,

    [StringValue("performedBy")]
    PERFORMEDBY,

    [StringValue("REMARKS")]
    REMARKS,

    [StringValue("AGREEMENT_ID")]
    AGREEMENT_ID,

    [StringValue("ipAddress")]
    IPADDRESS,

    [StringValue("userAgent")]
    USERAGENT,

    [StringValue("BILLING_CONNECTOR")]
    BILLING_CONNECTOR,

    [StringValue("transaction.confirmed")]
    STRIPE_CONFIRMATION_STATUS,

    [StringValue("original-transaction-key")]
    ORIGINAL_TRANSACTION_KEY,

    [StringValue("stripe-charge-id")]
    STRIPE_CHARGE_ID,

    [StringValue("stripe-customer-id")]
    STRIPE_CUSTOMER_ID,

    [StringValue("AGREEMENT_TERMINATED_AS_SERVICE_PLAN_DOWNGRADED")]
    AGREEMENT_TERMINATED_AS_SERVICE_PLAN_DOWNGRADED,

    [StringValue("PreviousAgreementId")]
    PREVIOUS_AGREEMENT_ID,

    [StringValue("stripe-subscription-id")]
    STRIPE_SUBSCRIPTION_ID
}

public enum TransactionType
{
    CAPTURE_PAYMENT_WITH_REGISTER,
    CAPTURE_PAYMENT_WITH_UPGRADE,
    CAPTURE_REGULAR_RECURRENT_PAYMENT,
    CAPTURE_PAYG_RECURRENT_PAYMENT,
    VOID_PAYMENT,
    CAPTURE_FIRST_REGULAR_PAYMENT
}

public enum FuturePayStatus
{
    [StringValue("service plan upgraded")]
    SERVICE_PLAN_UPGRADED,

    [StringValue("merchant cancelled")]
    MERCHANT_CANCELLED,

    [StringValue("User Deleted")]
    USER_DELETED,

    [StringValue("Customer Cancelled")]
    CUSTOMER_CANCELLED,

    AGREEMENT_TERMINATED_AS_SERVICE_PLAN_UPGRADED,
    AGREEMENT_TERMINATED_BY_ADMIN
}

public enum SSLAuthenticationAttribute
{
    VERIFY_SSL,
    VERIFY_SSL_PASSWORD
}

public enum EnterpriseStatus
{
    ACTIVE = 1,
    INACTIVE = 0
}

public enum InvitedUserStatus
{
    PENDING = 0,
    ACCEPTED = 1,
    REJECTED = 2
}

public enum User_AccessLevel
{
    ALLOW_ACCESS = 1,
    DENY_ACCESS = 0
}

public enum LoginAuthentication
{
    SIGNINGHUB_ID,
    NONE
}

public enum PaymentModes
{
    WORLD_PAY_LIVE,
    WORLD_PAY_TEST,
    STRIPE_PAYMENT_MODE_LIVE,
    STRIPE_PAYMENT_MODE_TEST
}

public enum WorldPayConnectionParameters
{
    INSTALLATION_ID,
    LIVE_INSTANCE_URL,
    TEST_INSTANCE_URL,
    ADMINISTRATION_LIVE_INSTANCE_URL,
    ADMINISTRATION_TEST_INSTANCE_URL,
    ADMINISTRATION_INSTALLATION_ID,
    ADMINISTRATION_INSTALLATION_PASSWORD,
    PAYMENT_DESCRIPTION,
    MARGIN_DAYS,
    PAYMENT_MODE
}

public enum PaymentMode
{
    MONTHLY = 1,
    YEARLY = 2
}

public enum Currency_Unit
{
    EUR,
    USD,
    GBP
}

public enum SignatureKeyLocation
{
    SERVER,
    LOCAL,
    MOBILE
}

[JsonConverter(typeof(StringEnumConverter))]
public enum SignatureAppreanceOption
{
    COMPANY_LOGO,
    HAND_SIGNATURE,
    DETAILED_SIGNATURE
}

public enum SignatureFont
{
    [StringValue("phontphreaks")]
    PHONT_PHREAKS
}

public enum BillingModel
{
    ONLINE = 1,
    OFFLINE = 2,
    NOBILLING = 3,
    NOBILLING_TRIAL = 4
}

public enum EnterpriseUserStatus
{
    ENABLED = 1,
    DISABLED = 0
}

public enum SAMLAttribute
{
    LOGO_BASE64
}

public enum Privacy
{
    PRIVATE = 0,
    PUBLIC = 1
}

public enum SAMLProtocoles
{
    [StringValue("urn:oasis:names:tc:SAML:2.0:protocol")]
    SAML_20_Protocole,

    [StringValue("urn:oasis:names:tc:SAML:2.0:assertion")]
    SAML_20_ASSERTION,

    [StringValue("urn:oasis:names:tc:SAML:2.0:ac:classes:Password")]
    SAML_20_AC_CLASSES_PASSWORD
}

public enum SAMLConnectorDetail
{
    SAML_CONNECTOR_PARAM_SP_CERTIFICATE,
    SAML_CONNECTOR_PARAM_SP_CERTIFICATE_PASSWORD,
    SAML_CONNECTOR_PARAM_SP_META_DATA_WANT_ASCERTION_SIGNED,
    SAML_CONNECTOR_PARAM_IDP_HTTP_POST_LOGIN_URL,
    SAML_CONNECTOR_PARAM_IDP_HTTP_POST_LOGOUT_URL,
    SAML_CONNECTOR_PARAM_IDP_HTTP_REDIRECT_LOGIN_URL,
    SAML_CONNECTOR_PARAM_IDP_HTTP_REDIRECT_LOGOUT_URL,
    SAML_CONNECTOR_PARAM_IDP_SIGNING_CERTIFICATE,
    SAML_CONNECTOR_PARAM_BINDING_TYPE,
    SAML_CONNECTOR_PARAM_SP_SIGNATURE_ALGORITHM,
    SAML_CONNECTOR_PARAM_IDP_CERT_FILE_INFO,
    SAML_CONNECTOR_PARAM_SP_CERT_FILE_INFO,
    SAML_CONNECTOR_PARAM_SP_META_DATA_WANT_AUTHENTICATION_REQUEST_SIGNED,
    SAML_CONNECTOR_PARAM_SP_META_DATA_EXPORT,
    SAML_CONNECTOR_PARAM_IDP_META_DATA,
    SAML_EMAIL_ATTRIBUTE,
    SAML_NAME_ATTRIBUTE
}

public enum AuditDeltaDisplayKey
{
    CERT,
    SECRET,
    KEY,
    ADMIN_ACTIVITY_DETAILS_PROVIDERS,
    COMMON_ENABLE
}

public enum SAMLNameIdentifierFormates
{
    [StringValue("urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress")]
    EMAIL_ADDRESS,

    [StringValue("urn:oasis:names:tc:SAML:2.0:nameid-format:transient")]
    TRANSIENT,

    [StringValue("urn:oasis:names:tc:SAML:2.0:nameid-format:persistent")]
    PERSISTENT,

    [StringValue("urn:oasis:names:tc:SAML:2.0:nameid-format:unspecified")]
    UNSPECIFIED
}

public enum SAMLBindingType
{
    [StringValue("urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST")]
    HTTP_POST = 1,

    [StringValue("urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect")]
    HTTP_REDIRECT = 2
}

public enum SignatureAlgorithm
{
    [StringValue("http://www.w3.org/2000/09/xmldsig#rsa-sha1")]
    SHA1 = 1,

    [StringValue("http://www.w3.org/2001/04/xmldsig-more#rsa-sha256")]
    SHA256 = 2
}

public enum DOCUMENT_SOURCES
{
    FILE_SYSTEM,
    LIBRARY,
    SHAREPOINT,
    SALES_FORCE,
    DROPBOX,
    MS_OFFICE,
    GOOGLE_DRIVE,
    ONEDRIVE,
}

public enum FileSizeUnit
{
    Byte,
    KByte,
    MByte
}

public enum VerisecMobileAuthentication
{
    [StringValue("Transaction text shown on freja mobile app at the time of login")]
    VERISEC_AUTHENTICATION_MOBILE_TRANSACTION_TEXT,

    [StringValue("Transaction text shown on freja mobile app at the time of signing")]
    VERISEC_SIGNING_MOBILE_TRANSACTION_TEXT,

    [StringValue("Push notification text for freja mobile authentication")]
    VERISEC_MOBILE_PUSH_NOTIFICATION_TEXT,

    [StringValue("Push notification title for freja mobile authentication")]
    VERISEC_MOBILE_PUSH_NOTIFICATION_TITLE,

    [StringValue("Server url for freja mobile authentication")]
    VERISEC_MOBILE_ID_CONNECTOR_PARAM_SERVER_URL
}

public enum VerisecMobileAuthenticationResponse
{
    CANCELED = 0,
    APPROVED = 1,
    TIME_OUT = 2,
    NOT_PROVISIONED = 3
}

public enum StorageMedia
{
    FILE_SYSTEM = 1,
    AZURE_BLOB = 2,
    DATABASE_SYSTEM = 3
}

public enum DocumentStoreCategory
{
    [StringValue("Templates")]
    TEMPLATES = 1,

    [StringValue("Documents")]
    DOCUMENTS = 2,

    [StringValue("Library")]
    LIBRARY = 3,
}

public enum DEKOperationType
{
    ENCRYPTION,
    DECRYPTION
}

public enum DEKOperationResponse
{
    SUCCESS,
    FAILED
}

public enum DeviceOSType
{
    IOS = 0,
    ANDROID = 1
}

public enum ExcelReports
{
    [StringValue("Accounts")]
    ACCOUNTS,

    [StringValue("IndividualAccounts")]
    INDIVIDUALACCOUNTS,

    [StringValue("EnterpriseAccounts")]
    ENTERPRISEACCOUNTS,

    [StringValue("LockedAccounts")]
    LOCKEDACCOUNTS,

    [StringValue("InactiveAccounts")]
    INACTIVEACCOUNTS,

    [StringValue("Payments")]
    PAYMENTS,

    [StringValue("OnlinePayments")]
    ONLINEPAYMENTS,

    [StringValue("OfflinePayments")]
    OFFLINEPAYMENTS
}

public enum Reports
{
    [StringValue("REPORTS_MONTH")]
    MONTH,

    [StringValue("REPORTS_ACCOUNT_TOTAL_ACTIVATED_USERS")]
    ACTIVATED,

    //Workflow Stats
    [StringValue("REPORTS_WORKFLOW_NEVER_SHARED")]
    NEVERSHARED,

    [StringValue("REPORTS_WORKFLOW_SHARED_ONCE")]
    SHAREDONCE,

    [StringValue("REPORTS_WORKFLOW_SHARED_TWO_TO_FIVE")]
    SHARED5TIMES,

    [StringValue("REPORTS_WORKFLOW_SHARED_MORE_THAN_FIVE")]
    SHAREDMORE,

    // Account Stats
    [StringValue("REPORTS_ACCOUNT_TOTAL_REGISSTERED_USERS")]
    TOTALREGISTERED,

    [StringValue("REPORTS_ACCOUNT_TOTAL_INACTIVATED_USERS")]
    INACTIVE,

    [StringValue("REPORTS_ACCOUNT_TOTAL_REGISTERED_STATUS_USERS")]
    REGISTERED,

    [StringValue("REPORTS_ACCOUNT_TOTAL_MARKDELETED_USERS")]
    MARKDELETED,

    //Signature Stats
    [StringValue("REPORTS_SIGNATURE_NEVER_SIGNED")]
    NEVERSIGNED,

    [StringValue("REPORTS_SIGNATURE_SIGNED_ONCE")]
    SIGNEDONCE,

    [StringValue("REPORTS_SIGNATURE_SIGNED_TWO_TO_FIVE")]
    SIGNED5TIMES,

    [StringValue("REPORTS_SIGNATURE_SIGNED_MORE_THAN_FIVE")]
    SIGNEDMORE,

    //Login Stats
    [StringValue("REPORTS_ACCOUNT_LOGIN_NEVER_LOGIN_USERS")]
    NEVERLOGIN,

    [StringValue("REPORTS_ACCOUNT_LOGIN_ONCE_USERS")]
    LOGINONCE,

    [StringValue("REPORTS_ACCOUNT_LOGIN_TWO_TO_FIVE_USERS")]
    LOGIN5TIMES,

    [StringValue("REPORTS_ACCOUNT_LOGIN_MORE_THAN_FIVE_USERS")]
    LOGINMORE,

    // Billing Stats
    [StringValue("REPORTS_BILLING_NEW_PAYMENTS")]
    FIRSTPAYMENTCOUNT,

    [StringValue("REPORTS_BILLING_NEW_PAYMENTS_REVENUE")]
    FIRSTPAYMENTAMOUNT,

    [StringValue("REPORTS_BILLING_RECURRENT_PAYMENTS")]
    RECURRENTPAYMENTCOUNT,

    [StringValue("REPORTS_BILLING_RECURRENT_PAYMENTS_REVENUE")]
    RECURRENTPAYMENTAMOUNT,

    [StringValue("REPORTS_BILLING_TOTAL_PAYMENTS")]
    TOTALPAYMENTCOUNT,

    [StringValue("REPORTS_BILLING_TOTAL_PAYMENTS_REVENUE")]
    TOTALPAYMENTAMOUNT,

    // Serviceplan Stats
    [StringValue("REPORTS_SERVICEPLAN_ID")]
    ID,

    [StringValue("COMMON_NAME")]
    NAME,

    [StringValue("REPORTS_SERVICEPLAN_ASSOCIATED_USERS")]
    ASSOCIATEDUSERS,

    [StringValue("REPORTS_SIGNATURE_STATISTICS_TOTAL_SIGNATURE")]
    TOTALSIGNATURES,

    [StringValue("ADVANCED_ELECTRONIC_SIGNATURE")]
    DSIGNATURE,

    [StringValue("ELECTRONIC_SIGNATURE")]
    ESIGNATURE,

    [StringValue("ELECTRONIC_SEAL")]
    ESEAL,

    [StringValue("ADVANCED_ELECTRONIC_SEAL")]
    ADESEAL,

    [StringValue("QUALIFIED_ELECTRONIC_SEAL")]
    QESEAL,

    [StringValue("REPORTS_SIGNATURE_STATISTICS_INPERSON_SIGNATURE")]
    INPERSON,

    [StringValue("REPORTS_DOCUMENT_STATS_SIGNED")]
    SIGNED,

    [StringValue("REPORTS_DOCUMENT_STATS_DECLINED")]
    DECLINED,

    [StringValue("REPORTS_DOCUMENT_STATS_REVIEWED")]
    APPROVED,

    [StringValue("REPORTS_DOCUMENT_STATS_UPDATED")]
    SUBMITTED,

    [StringValue("REPORTS_DOCUMENT_STATS_COMPLETED")]
    COMPLETED,

    [StringValue("REPORTS_DOCUMENT_STATS_DISKSPACE")]
    DISKSPACE,

    [StringValue("COMMON_EMAIL")]
    EMAILADDRESS,

    [StringValue("COMMON_COMPANY_NAME")]
    COMPANYNAME,

    [StringValue("COMMON_JOB_TITLE")]
    JOBTITLE,

    [StringValue("COMMON_MOBILE_NUMBER")]
    MOBILENUMBER,

    [StringValue("ACTIVATED")]
    STATUS,

    [StringValue("USER_ACCESSLEVEL_ENABLED")]
    ACCESSLEVEL,

    [StringValue("COMMON_NATIONAL_ID_NUMBER")]
    NID,

    [StringValue("COMMON_ROLE")]
    DEFAULTROLENAME,

    [StringValue("COMMON_CREATED_ON")]
    CREATEDON,

    [StringValue("COMMON_ROLE")]
    ASSIGNEDROLENAME,

    [StringValue("SETTINGS_ENTERPRISE_USERS_CERTIFICATE_COMMON_NAME")]
    COMMONNAME,

    [StringValue("HIGH_TRUST_ADVANCED")]
    AATL,

    [StringValue("QUALIFIED_ELECTRONIC_SIGNATURE")]
    QES,

    [StringValue("ENTERPRISE_NAME")]
    ENTERPRISENAME,

    [StringValue("REPORTS_ACCOUNT_CONSUMED_SMS_COUNT")]
    SMSCOUNT,

    [StringValue("REPORTS_BILLING_TOTAL_VAT")]
    TOTALVATAMOUNT,

    [StringValue("UPLOADED")]
    UPLOADED,

    [StringValue("SHARED")]
    SHARED,
}

public enum SystemSettingGroupName
{
    ADVANCED,
    BILLING,
    GENERAL,
    HIDDEN,
    PROCESS_EVIDENCE,
    DOCUMENT_LOCK,
    REPORT,
    STORAGE,
    DOCUMENT_SETTING
}

public enum InstanceType
{
    ADMIN,
    WEB,
    API,
    MOBILE_WEB,
    OFFICE,
    DEMO,
    CORE
}

public enum InstanceStatus
{
    RUNNING,
    PENDING,
    STOPPED
}

public enum ResourceURI
{
    [StringValue("/settings/signatures/appearance/design/")]
    DESIGN_PREVIEW_URL,

    [StringValue("/settings/profile/general/photo/")]
    SIGNER_PHOTO_URL,

    [StringValue("/account/log/{logId}/certificate")]
    CERTIFICATE_BASE_USER_ACTIVITY_LOG_URL,

    [StringValue("/packages/")]
    CERTIFICATE_BASE_WORKFLOW_HISTORY_URL,

    [StringValue("/enterprise/branding/logo")]
    ENTERPRISE_BRANDING_LOGO_URL,

    [StringValue("/enterprise/branding/favicon")]
    ENTERPRISE_BRANDING_FAVICON_URL,

    [StringValue("/system/configurations/branding/logo")]
    ADMIN_BRANDING_LOGO_URL,

    [StringValue("/system/configurations/branding/favicon")]
    ADMIN_BRANDING_FAVICON_URL,

    [StringValue("/authorization/requests/{request_id}/bytes")]
    AUTHORIZED_SIGNING_REQUEST_URL,

    [StringValue("/settings/signatures/appearance/initials/text")]
    SIGNATURE_APPEARANCE_INITIAL_TEXT_IMAGE_URL,

    [StringValue("/settings/signatures/appearance/initials/upload")]
    SIGNATURE_APPEARANCE_INITIAL_UPLOAD_IMAGE_URL,

    [StringValue("/settings/signatures/appearance/hand_signature/mobile/text")]
    SIGNATURE_APPEARANCE_MOBILE_TEXT_IMAGE_URL,

    [StringValue("/settings/signatures/appearance/hand_signature/mobile/upload")]
    SIGNATURE_APPEARANCE_MOBILE_UPLOAD_IMAGE_URL,

    [StringValue("/settings/signatures/appearance/hand_signature/web/text")]
    SIGNATURE_APPEARANCE_WEB_TEXT_IMAGE_URL,

    [StringValue("/settings/signatures/appearance/hand_signature/web/upload")]
    SIGNATURE_APPEARANCE_WEB_UPLOAD_IMAGE_URL,

    [StringValue("/preview")]
    DEFAULT_PREVIEW_LABEL
}

public enum Base64LoggingDetailKey
{
    LOG_HAND_SIGNATURE_IMAGE,
    LOG_ADD_TEXT_IMAGE,
}

public enum Settings
{
    ENTERPRISE_GROUPS,
    PERSONAL_GROUPS,
    ENTERPRISE_CONTACTS,
    PERSONAL_CONTACTS,
    ENTERPRISE_LIBRARY,
    PERSONAL_LIBRARY,
    ENTERPRISE_LEGAL_NOTICES,
    PERSONAL_LEGAL_NOTICES,
    ENTERPRISE_CERTIFICATE_FILTERS,
    ENTERPRISE_TEMPLATES,
    PERSONAL_TEMPLATES,
    ENTERPRISE_INTEGRATION_INTEGRATION_USER,
    TEST
}

public enum SettingTableName
{
    Template,
    LegalNotice,
    Contact,
    Group,
    Setting,
    DocumentLibrary
}

public enum ContactStatus
{
    ENABLED = 0,
    DISABLED = 1
}

public enum OTPAuthenticationType
{
    Login,
    DocumentAccess,
    Signing,
    BulkSign
}

public enum OTPMethod
{
    EMAIL,
    SMS
}

public enum OTPLength
{
    Four = 4,
    Six = 6,
    Nine = 9
}

public enum PaymentProviders
{
    STRIPE,
    WORLD_PAY
}

public enum StripeConnectionParameters
{
    TAXAMO_LIVE_PUBLIC_TOKEN,
    TAXAMO_LIVE_PRIVATE_TOKEN,
    TAXAMO_TEST_PUBLIC_TOKEN,
    TAXAMO_TEST_PRIVATE_TOKEN,
    STRIPE_LIVE_PUBLIC_TOKEN,
    STRIPE_LIVE_PRIVATE_TOKEN,
    STRIPE_TEST_PUBLIC_TOKEN,
    STRIPE_TEST_PRIVATE_TOKEN,
    STRIPE_PAYMENT_MODE
}

public enum PushNotificationType
{
    [StringValue("Authorized Remote Signing")]
    ARS,

    [StringValue("Document")]
    Document
}

public enum Provider
{
    [StringValue("Microsoft Sql Server")]
    SQL,

    [StringValue("Oracle")]
    ORACLE,

    POSTGRESQL,
    MYSQL
}

public enum VeriseceIDAuthentication
{
    [StringValue("Freja eID host url")]
    HOST_URL,

    SSL_CLIENT_CERTIFICATE_LOCATION,

    [StringValue("Password of Relying Party PFX file in request")]
    SSL_CLIENT_CERTIFICATE_PASSWORD,

    TIMEOUT,

    [StringValue("Relying Party PFX file in request")]
    SSL_CLIENT_CERTIFICATE
}

public enum VerisecEidAuthenticationResponse
{
    STARTED = 0,
    DELIVERED_TO_MOBILE = 1,
    CANCELED = 2,
    REJECTED = 3,
    APPROVED = 4,
    EXPIRED = 5
}

public enum DataDirectoryMode
{
    FILE_SYSTEM,
    AZURE_BLOB,
    DATABASE_SYSTEM,
}

public enum AzureBlobConnectorDetails
{
    AZURE_BLOB_ACCOUNT_NAME,
    AZURE_BLOB_ACCOUNT_KEY
}

public enum UserIdentityType
{
    RUT,
    CERT,
    VO_ID,

    //UNIQUE_NO,
    IdentityProviderUniqueId
}

public enum UsageStatsType
{
    WORKFLOWS,
    DISKSPACE,
    USERS,
    TEMPALTES,
    SIGNATURES,
    SIMPLE_ELECTRONIC_SIGNATURES
}

public enum DocumentActionType
{
    UPLOADED = 1,
    SHARED = 2,
    SIGNED = 3,
    DECLINED = 4,
    APPROVED = 5,
    SUBMITTED = 6,

    //COMPLETED = 7,
    DELETED = 8,

    DISKSPACE = 9 /*This is just for diskspace reports, never dump it in Database */
}

public enum PaymentNumber
{
    ALLPAYMENTS = 1,
    NEWPAYMENTS = 2,
    RECURRING = 3
}

public enum UserActionType
{
    REGISTERED = 1,
    ACTIVATED = 2,
    DELETED = 3,
    SMS_OTP = 4,
    EMAIL_OTP = 5,
}

public enum SignedBy
{
    INTERNAL = 1,
    EXTERNAL = 2
}

public enum DocumentActionSignatureType
{
    E_SIGNATURE = 1,
    ELECTRONIC_SEAL = 2,
    ADVANCED_ELECTRONIC_SIGNATURE = 3,
    IN_PERSON = 4,
    IN_PERSON_WITNESS = 5,
    HAND_SIGNATURE = 6,
    ALL_SIGNATURES = 7,
    HIGH_TRUST_ADVANCED = 8,
    QUALIFIED_ELECTRONIC_SIGNATURE = 9,
    ADVANCED_ELECTRONIC_SEAL = 10,
    QUALIFIED_ELECTRONIC_SEAL = 11
}

public enum PlotByTime
{
    DAY = 1,
    WEEK = 2,
    MONTH = 3,
    YEAR = 4
}

[JsonConverter(typeof(StringEnumConverter))]
public enum WorkflowMode
{
    ME_AND_OTHERS = 1,
    ONLY_OTHERS = 2,
    ONLY_ME = 3
}

public enum WebHookTypes
{
    DCOUMENT_PROCESSING_REPORT = 1,
    WORKFLOW_COMPLETION_REPORT = 2,
    USER_UPDATE_REPORT = 3,
}

public enum SMSPrviderHTTPVerb
{
    [StringValue("GET")]
    GET,

    [StringValue("POST")]
    POST
}

public enum SMSProviderParameter
{
    SMS_PROVIDER_URL,
    SMS_PROVIDER_HTTP_METHOD,
    SMS_PROVIDER_HEADER_AUTHORIZATION,
    SMS_PROVIDER_HEADER_CONTENT_TYPE,
    SMS_PROVIDER_HEADER_AUTHORIZATION_TOKEN,
    SMS_PROVIDER_HEADER_USER_NAME,
    SMS_PROVIDER_HEADER_PASSWORD,
    SMS_PROVIDER_BODY_PARAM_NUMBER,
    SMS_PROVIDER_BODY_PARAM_MESSAGE
}

public enum AuthorizationTypes
{
    [StringValue("No Auth")]
    NO_AUTH,

    [StringValue("Bearer Token")]
    BEARER_TOKEN,

    [StringValue("Basic Auth")]
    BASIC
}

public enum ContentTypes
{
    [StringValue("application/json")]
    APPLICATION_JSON,

    [StringValue("application/x-www-form-urlencoded")]
    APPLICATION_FORM_URL_ENCODED,

    [StringValue("multipart/form-data")]
    MULTIPART_FORM_DATA
}

public enum RequestParameter
{
    HEADER_PARAMTER = 1,
    BODY_PARAMTER = 2
}

public enum CertificateAction
{
    CERTIFICATE_REVOKED_OR_EXPIRED_ACTION_CREATED,
    CERTIFICATE_REVOKED_OR_EXPIRED_ACTION_RENEWED,
    CERTIFICATE_REVOKED_OR_EXPIRED_ACTION_REVOKED
}

public enum CertificateActionReason
{
    CERTIFICATE_REVOKED_OR_EXPIRED_REASON_PASSWORD,
    CERTIFICATE_REVOKED_OR_EXPIRED_REASON_DELETED,
    CERTIFICATE_REVOKED_OR_EXPIRED_REASON_CHANGE_SERVICE_PLAN,
    CERTIFICATE_REVOKED_REASON_COMMON_NAME_UPDATED,
    CERTIFICATE_CREATED_REASON_COMMON_NAME_UPDATED,
    CERTIFICATE_REVOKED_OR_EXPIRED_REASON_EXPIRED,
    CERTIFICATE_REVOKED_REASON_USER_EMAIL_UPDATED
}

public enum SigningType
{
    SERVER_SIDE_SIGN,
    CLIENT_SIDE_SIGN,
    WORD_SIGN,
    AUTHORIZED_REMOTE_SIGNING,
    XML_SIGN
}

public enum GoogleCaptchaProvider
{
    GOOGLE_CONNECTOR_CAPTCHA_SECRET_KEY,
    GOOGLE_CONNECTOR_CAPTCHA_PUBLIC_KEY
}

public enum CACHE
{
    CONNECTORS,
    REPORT_FILTERS,
    SERVICEPLANS
}

public enum IntegrationHideDocumentType
{
    NONE = 0,
    HIDE_FROM_FIRST_RECIPIENT_ONLY = 1,
    HIDE_FROM_ALL_RECIPIENTS = 2
}

public enum DocumentProcessingReportAction
{
    RECALLED,
    REMINDED,
    DELETED,
    EVIDENCE_REPORT_GENERATED
}

public enum SignatureDisplayType
{
    VISIBLE = 0,
    INVISIBLE = 1
}

public enum WorkflowCompletionReportStatus
{
    PUBLISHED,
    PUBLISHED_FAILED
}

public enum BulkSignAction
{
    SHARE,
    SIGN,
    SIGN_AND_SHARE
}

public enum ItsmeResponse
{
    SUCCESS,
    FAILED,
    CANCELLED
}

public enum ServicePlanAuditLogKeys
{
    SERVICE_PLAN_SETTINGS_ALL_SIGNATURE_TYPES,
    SERVICE_PLAN_SETTINGS_DIGITAL_SIGNATURE,
    SERVICE_PLAN_SETTINGS_ELECTRONIC_SIGNATURE,

    SERVICE_PLAN_DOCUMENT_LOG_BASIC,
    SERVICE_PLAN_DOCUMENT_LOG_DETAILED,
    SERVICE_PLAN_TYPE_INDIVIDUAL,
    SERVICE_PLAN_TYPE_ENTERPRISE,
    ONLINE_BILLING,
    OFFLINE_BILLING,
    NONE,
    NO_BILLING_TRIAL,
    NO_BILLING,
    BILLING_PAYMENT_TYPE_PAY_REGULARLY,
    BILLING_MODEL_PAY_AS_GO,
    COMMON_NAME,
    SERVICEPLAN_PUBLIC,
    ACCOUNTS_USER_DETAIL_WORKFLOWS,
    ACCOUNTS_USER_DETAIL_SIGNATURES,
    ACCOUNTS_USER_DETAIL_SIMPLE_ELECTRONIC_SIGNATURES,
    SERVICE_PLAN,
    WITNESS_SIGN_PROFILE,
    SERVER_AES_CERTIFICATION_PROFILE,
    ALLOWED_PRIVATE_AUTHENTICATION_PROFILES,
    COMMON_UNLIMITED,
    SERVICE_PLAN_SETTINGS_ENABLE_USER_DELETION,
    SERVICE_PLAN_SETTINGS_USER_DELETION_DAYS,
    SERVICE_PLAN_SETTINGS_USER_DELETION_EMAIL,
    SERVICE_PLAN_SETTINGS_ENABLE_DELETION,
    SERVICE_PLAN_SETTINGS_DELETION_DAYS,
    SERVICE_PLAN_SETTINGS_ATTACH_DOCUMENT_IN_EMAIL,
    SERVICE_PLAN_SETTINGS_NOTIFY_EMAIL_DAYS,
    SERVICE_PLAN_SETTINGS_OTP_CONNECTOR,
    SERVICE_PLAN_SETTINGS_OTP_LENGTH,
    SERVICE_PLAN_SETTINGS_OTP_RETRY_TIME,
    SERVICE_PLAN_SETTINGS_OTP_EXPIRY_TIME,
    SERVICE_PLAN_SETTINGS_ENABLE_OTP,
    SERVICE_PLAN_CONSTRAINT_USERS,
    VIRTUAL_ID_PROFILE_ID,
    REMOTE_AUTHORIZATION_SIGNING_EXPIRY_TIME,//Mehroz
    SERVICE_PLAN_SETTINGS_ENABLE_REMOTE_AUTHORIZATION,
    OTP_LENGTH,
    OTP_RETRY_TIME,
    OTP_EXPIRY_TIME,
    DOCUMENT_DELETION_DURATION,
    DOCUMENT_DELETION_EMAIL_DURATION,
    DOCUMENT_DELETION_EMAIL_NOTIFICATION,
    USER_DELETION_DURATION,
    USER_DELETION_EMAIL,
    USER_DELETION_EMAIL_DURATION,
    DefaultWitnessSignProfile,
    SERVICE_PLAN_SETTINGS_ENABLE_WITNESS_SIGNATURES,
    SERVICE_PLAN_SETTINGS_ENABLE_SOLE_CONTROL,
    IsCSPProvisioning,
    SERVER_CSP_USER_AUTO_DELETION,
    SERVICE_PLAN_SETTINGS_ENABLE_SMTP,
    SMTPConnector,
    OTPConnector,
    IsRemoteAuthorization,
    SERVICE_PLAN_SETTINGS_ELECTRONIC_SIGNATURE_WITNESS,
    SERVICE_PLAN_SETTINGS_WITNESS_SIGN_CAPACITY,
    OTP_SEND_EMAIL
}

public enum ConnectorAttribute
{
    SAML_CONNECTOR_POST,
    SAML_CONNECTOR_REDIRECT,
    ALGORITHM_SHA1,
    ALGORITHM_SHA256,
    SAML_CONNECTOR_PARAM_SP_META_DATA_EXPORT,
    SAML_CONNECTOR_PARAM_IDP_SIGNING_CERTIFICATE,
    SAML_CONNECTOR_PARAM_IDP_META_DATA,
    SMS_PROVIDER_BODY_BUTTON,
    SMS_PROVIDER_HEADER_BUTTON,
    CERT_FILE_INFO,
    SAML_CONNECTOR_PARAM_IDP_CERT_FILE_INFO,
    SAML_CONNECTOR_PARAM_SP_CERT_FILE_INFO,
    SSL_CLIENT_CERTIFICATE_FILE_INFO,
    LOGO,
    LOGO_FILE_INFO
}

public enum ProfileAuditLogKeys
{
    SIGNATURES_SERVER,
    SIGNATURES_LOCAL,
    SIGNATURES_MOBILE,
    ADSS_SIGNING_PROFILE_ID,
    LOCAL_SIGNING_CONNECTOR,
    MOBILE_SIGNING_CONNECTOR,
    MS_OFFICE_ADSS_SIGNING_PROFILE_ID,
    SERVER_SIGNING_CONNECTOR,
    XML_CONFIGURATION_PROFILE_SIGNING_ENABLED,
    XML_CONFIGURATION_SIGNING_PROFILE_ID,
    ADSS_GOSIGN_PROFILE_ID,
    KEYSTORE_BELGIAN_EID,
    KEYSTORE_PKCS11
}

public enum UserAuditLogKeys
{
    USER_ACCESSLEVEL_ENABLE,
    USER_ACCESSLEVEL_DISABLE,
    REGISTERED,
    ACTIVATED,
    ACCOUNTS_REGISTER_SERVICE_PLAN
}

public enum BillingAuditLogKeys
{
    BILLING_MODEL_MONTHLY,
    BILLING_MODEL_YEARLY,
    SERVICE_PLAN
}

public enum BillingSearchCriteriaAuditLogKeys
{
    WORLDPAY_AGREEMENT_TERMINATED,
    BILLING_MODULE_TERMINATE_PLAN,
    ALL_SEARCH,
    ACCOUNTS_SEARCH_NAME_VALUE_ALL,
    TRANSACTION_LOG,
    BILLING_TRANSACTIONS_LOGS,
    BILLING_ALL_TRANSACTIONS,
    WORLDPAY_PAYMENT_FAILURE,
    WORLDPAY_RECURRENT_PAYMENT_FAILURE,
    ALL_TRANSACTION,
    BILLING_SEARCH_FAILED,
    BILLING_SEARCH_CANCELED
}

public enum LogSearchCriteriaAuditLogKeys
{
    COMMON_ALL,
    FROM,
    TO
}

public enum CertificateAuditLogKeys
{
    ACCOUNTS_PROFILE_USER_CERTIFICATE
}

public enum AccountsSearchCriteriaAuditLogKeys
{
    ALL,
    ACTIVATED,
    YES,
    NO
}

public enum EnterpriseRoleAuditLogKeys
{
    SETTINGS_ROLE_USER_DEFINED,
    SETTINGS_ROLE_FIXED,
    SETTINGS_ROLE_PREDEFINED,
    PREDEFINED,
    COMMON_DEFAULT,
    SETTINGS_APPEARANCE_DRAW_SIGNATURE,
    SETTINGS_APPEARANCE_TEXTUAL_SIGNATURE,
    SETTINGS_APPEARANCE_UPLOAD_SIGNATURE,
    WORKFLOW_TYPE,
    WORKFLOW_TYPE_SEQUENTIAL,
    WORKFLOW_TYPE_INDIVIDUAL,
    WORKLFOW_TYPE_PARALELL,
    WORKFLOW_TYPE_CUSTOM
}

public enum WorkFlowMode
{
    NEW_WORKFLOW_ME_AND_OTHERS = 1,
    NEW_WORKFLOW_JUST_OTHERS = 2,
    NEW_WORKFLOW_ONLY_ME = 3
}
public enum DefaultSignatureOption
{
    DRAW,
    TEXT,
    UPLOAD
}
public enum GroupAuditLogKeys
{
    LOG_GROUP_MEMBERS
}

public enum CSPResourceURI
{
    [StringValue("adss/service/csp/v2/users/register")]
    REGISTER_CSP_USER,

    [StringValue("adss/service/csp/v2/users/certs/{user_id}")]
    PUSH_CSP_CERTIFICATE,

    [StringValue("adss/service/csp/v2/users/{user_id}")]
    GET_CSP_USER,

    [StringValue("adss/service/csp/v2/users/certs/{user_id}")]
    GET_CSP_USER_CERTIFICATE,

    [StringValue("adss/service/csp/v2/users/password/change")]
    CHANGE_CSP_USER_PASSWORD,

    [StringValue("adss/service/csp/v2/users/certs/{user_id}/{cert_alias}")]
    DELETE_CSP_USER_CERTIFICATE,

    [StringValue("adss/service/csp/v2/users/{user_id}")]
    DELETE_CSP_USER,

    [StringValue("adss/service/csp/v2/users/{user_id}")]
    UPDATE_CSP_USER,

    [StringValue("adss/service/csp/authenticate")]
    GET_ACCESS_TOKEN,

    [StringValue("adss/service/csp/v2/profiles/auth")]
    GET_AUTH_PROFILE,

    [StringValue("adss/service/csp/v2/users/password/reset/noauth")]
    RESET_CSP_USER_PASSWORD
}

public enum EnterpriseRoleOption
{
    [StringValue("AllowAdd")]
    ALLOW_ADD,

    [StringValue("AllowEdit")]
    ALLOW_EDIT,

    [StringValue("AllowDelete")]
    ALLOW_DELETE
}

public enum AuditLogFieldType
{
    COLOR,
    CHECKBOX,
    ROLE,
    IMAGE,
    MASK,
    HTML,
    FEATURE
}

public enum FolderType
{
    ALL
}

public enum KeyStore
{
    BELGIANEID = 1,
    PKCS11 = 2
}

public enum T1CConnectionParameters
{
    T1C_CONNECTOR_PARAM_API_KEY,
    API_KEY,
    KEY_STORE,
    HASH_ALGORITHM
}

public enum ADSSCertificateRevokeErrorCodes
{
    [StringValue("43006")]
    ERROR_CERTIFICATE_ALIAS_NOT_BELONG_TO_CLIENT,

    [StringValue("43007")]
    ERROR_CERTIFICATE_NOT_BELONG_TO_CLIENT,

    [StringValue("43023")]
    ERROR_CERTIFICATE_ALREADY_REVOKED,

    [StringValue("43039")]
    ERROR_CERTIFICATE_EXPIRED,

    [StringValue("43032")]
    ERROR_CERTIFICATE_NOT_REVOKED
}

public enum CommonAttributes
{
    [StringValue("name")]//for api string value is in camelCase
    COMMON_NAME
}

public enum ExportFileName
{
    [StringValue("Library")]
    LIBRARY,

    [StringValue("Templates")]
    TEMPLATE
}

public enum FileExtension
{
    [StringValue(".json")]
    JSON,

    [StringValue(".xlsx")]
    XLSX,

    [StringValue(".csv")]
    CSV
}

public enum TemplateStatus
{
    READ_ONLY = 1,
    NOT_READ_ONLY = 0
}

public enum CertificationRequestType
{
    CREATE,
    REVOKE,
    CHANGE_PASSWORD,
    RECOVER_KEY,
    GET_PROFILE_INFO
}

public enum CertificateStatus
{
    [StringValue("valid")]
    VALID,

    [StringValue("expired")]
    EXPIRED,

    [StringValue("revoked")]
    REVOKED,

    [StringValue("suspended")]
    SUSPENDED
}

public enum CertificateAttributes
{
    [StringValue("SUBJECT_DN")]
    SUBJECT_DN,

    [StringValue("rfc822Name")]
    RFC_822_NAME,

    [StringValue("CERTIFICATE")]
    RESPOND_WITH_CERTIFICATE,

    [StringValue("PKCS_12")]
    RESPOND_WITH_PKCS_12,

    [StringValue("PKCS_7")]
    RESPOND_WITH_PKCS_7,

    [StringValue("EXPIRY_DATE")]
    RESPOND_WITH_EXPIRY_DATE,

    [StringValue("X509CRL")]
    RESPOND_WITH_X509_CRL,

    [StringValue("OCSP")]
    RESPOND_WITH_OCSP,

    [StringValue("X509CertificateChain")]
    RESPOND_WITH_X509_CERTIFICATE_CHAIN
}

public enum SystemBranding
{
    [StringValue("Admin Branding")]
    ADMIN_BRANDING,

    [StringValue("custom")]
    CUSTOM
}

public enum LibraryType
{
    PRIVATE = 0,
    PUBLIC = 1
}

public enum HMAC
{
    HMAC
}

public enum UserSettings
{
    SIGNATURE_FONT
}

public enum ELECTRONIC_SIGNATURE
{
    OFF = 0,
    ANNOTATION = 1,
    WITNESS = 2
}

public enum DIGITAL_SIGNATURE
{
    OFF = 0,
    SERVER_SIDE = 1,
    LOCAL_SIDE = 2,
    ALL = 3
}

public enum AUTHENTICATION
{
    [StringValue("PASSWORD")]
    PASSWORD,

    [StringValue("")]
    NO_AUTHENTICAION,

    [StringValue("OTP")]
    ONE_TIME_PASSWORD
}

public enum SignatureDefaultLevelOfAssurance
{
    [StringValue("1")]
    DIGITAL,

    [StringValue("4")]
    E_SIGNATURE
}

public enum SigningResponseParameters
{
    [StringValue("Message")]
    MESSAGE,

    [StringValue("ERROR_CODE")]
    ERROR_CODE,
}

public enum SigningResponseCode
{
    [StringValue("41091")]
    INVALID_PASSWORD,

    [StringValue("58062")]
    AUTHORIZATION_REQUEST_DECLINED,
}

public enum DocumentFieldTypes
{
    SIGNATURE,
    IN_PERSON_SIGNATURE,
    INITIALS,
    TEXT,
    NAME,
    EMAIL,
    COMPANY,
    JOBTITLE,
    RADIOBOX,
    CHECKBOX,
    [StringValue("Date")]
    DATE,
    [StringValue("Number")]
    NUMBER,
    TEXTAREA,

    //v3 APIs
    ELECTRONIC_SIGNATURE,

    DIGITAL_SIGNATURE,

    [StringValue("None")]
    NONE,
    RADIO,
    QRCODE,
    UNIQUE_IDENTIFIER
}

public enum SupportedDocumentExtension
{
    PDF,
    DOCX,
    XML,
    DOC,
    XLS,
    XLSX,
    PPT,
    PPTX,
    ODT,
    RTF,
    TXT,
    ODS,
    CSV,
    TSV,
    PNG,
    ICO,
    JPG,
    GIF,
    TIF,
    TIFF,
    EMF,
    BMP,
    DOT,
    DOCM,
    DOTM,
    DOTX,
    OTT,
    XLSM,
    XLSB,
    XLTX,
    PCL,
    MHT,
    SVG,
    XPS,
    TEX,
    CGM,
    EPUB,
    POT,
    PPS,
    POTX,
    PPSX,
    ODP,
    PPTM,
    DXF,
    DWG,
    XLTM,
    HTML,
    XHTML,
    VSD,
    VSDX,
    VSS,
    VST,
    VSX,
    VTX,
    VDW,
    VDX,
    VSSX,
    VSTX,
    VSDM,
    VSSM,
    VSTM,
    PSD,
    MPP,
    MPT,
    ONE,
    FO,
    MSG,
    EML,
    FLATOPC
}

public enum EmailDirection
{
    RIGHT_TO_LEFT,
    LEFT_TO_RIGHT
}

public enum XmlSignatureMode
{
    ENVELOPING,
    ENVELOPED,
}

public enum XmlSignatureType
{
    XADES
}

public enum AuthenticationTypes
{
    [StringValue("None")]
    NONE,

    [StringValue("Basic")]
    BASIC,

    [StringValue("TLS")]
    TLS
}

public enum TSAProviderParameter
{
    TSA_HOST_URL,
    TSA_POLICY_ID,
    TSA_AUTHENTICATION,
    TSA_CLIENT_CERTIFICATE,
    TSA_CLIENT_CERTIFICATE_FILE_NAME,
    TSA_CLIENT_CERTIFICATE_PASSWORD,
    TSA_CLIENT_USERNAME,
    TSA_CLIENT_PASSWORD
}

public enum FieldValidationPlaceholders
{
    FOLDER_NAME,
    VIEWER_FIELD_NAME,
    VIEWER_FORM_FIELD_PLACEHOLDER,
    VIEWER_FORM_FIELDS_GROUP_NAME,
    VIEWER_SIGNATURE_SETTINGS_INPERSON_NAME
}

public enum SearchType
{
    PERSONAL = 1,
    ENTERPRISE = 2,
    ALL = 3
}

public enum RedisChannelType
{
    WORKFLOW,
    WORKFLOW_COMPLETED,
    ACCOUNT,
    ACCOUNT_ARCHIVE,
    BRANDING
}

public enum AscertiaURLs
{
    [StringValue("http://www.ascertia.com/license/")]
    LICENSE,
}

public enum ThirdPartyURLs
{
    [StringValue("https://www.googleapis.com")]
    GOOGLE_APIS,

    [StringValue("https://fcm.googleapis.com/fcm/send")]
    GOOGLE_API_SEND,

    [StringValue("https://www.googleapis.com/oauth2/v3/token")]
    GOOGLE_API_OAUTH2_TOKEN,

    [StringValue("https://www.googleapis.com/drive/v2/files/")]
    GOOGLE_DRIVE_UPLOAD,

    [StringValue("https://graph.microsoft.com")]
    MICROSOFT_GRAPH,

    [StringValue("https://login.microsoftonline.com")]
    MICROSOFT_LOGIN,

    [StringValue("https://login.microsoftonline.com/common/oauth2/v2.0/token")]
    MICROSOFT_OAUTH2_TOKEN,

    [StringValue("https://graph.microsoft.com/v1.0/me/drive/root")]
    MICROSOFT_GRAPH_ROOT_FOLDER_INFORMATION,

    [StringValue("https://api.linkedin.com")]
    LINKEDIN_API,

    [StringValue("https://www.linkedin.com")]
    LINKEDIN,

    [StringValue("https://services.taxamo.com/")]
    TAXAMO_SERVICE,

    [StringValue("https://api.dropbox.com/oauth2/token")]
    DROPBOX_OAUTH2_TOKEN,

    [StringValue("https://api.hubapi.com/contacts/v1/contact")]
    HUBAPI_CONTACTS,

    [StringValue("http://www.w3.org/2000/09/xmldsig#")]
    XMLDSIG,
}
public enum BulkActionStatus
{
    PENDING,
    COMPLETED
}

public enum BulkActionEnum
{
    REMOTE_AUTHORIZATION_REQURIED
}

public enum BulkSignatureInvisible
{
    ALL,
    TRUE,
    FALSE
}

public enum VerificationRequestHeaders
{
    [StringValue("ORIGINATOR_ID")]
    ORIGINATOR_ID,

    [StringValue("REQUEST_ID")]
    REQUEST_ID,

    [StringValue("RETURN_VALID_TO")]
    VALID_TO,

    [StringValue("RETURN_VALID_FROM")]
    VALID_FROM,

    [StringValue("RETURN_SIGNER_IDENTITY")]
    SIGNER_IDENTITY,

    [StringValue("RETURN_TSA_HASH_ALGORITHM")]
    TSA_HASH_ALGORITHM,

    [StringValue("RETURN_TSA_NAME")]
    TSA_NAME,

    [StringValue("RETURN_TIMESTAMP_TIME")]
    TIMESTAMP_TIME,

    [StringValue("RETURN_SERIAL_NUMBER")]
    SERIAL_NUMBER,

    [StringValue("RETURN_ISSUER_NAME")]
    ISSUER_NAME,

    [StringValue("VERIFICATION_PROFILE")]
    VERIFICATION_PROFILE,

    [StringValue("RETURN_LEI_INFO")]
    LEI_INFO,

    [StringValue("USE_VERIFICATION_TIME")]
    USE_VERIFICATION_TIME
}

public enum VerificationRequestParameters
{
    [StringValue("signature/PDF")]
    PDF_CONTENT_TYPE,
    [StringValue("signature/XAdES")]
    XML_CONTENT_TYPE
}

public enum ColorSpace
{
    RGB,
    CMYK,
    GREY
}

public enum SystemSettingPlaceholder
{
    [StringValue("[APPLICATION_NAME]")]
    APPLICATION_NAME
}
public enum Office_365_Authentication
{
    [StringValue("https://login.microsoftonline.com/common/oauth2/authorize")]
    AUTHORIZE_URL,

    [StringValue("OAuth/Office365CallBack")]
    CALL_BACK,

    [StringValue("https://graph.microsoft.com")]
    RESOURCE
}
public enum Azure_AD_Authentication
{
    [StringValue("https://login.microsoftonline.com/common/oauth2/authorize")]
    AUTHORIZE_URL,

    [StringValue("OAuth/AzureADCallBack")]
    CALL_BACK
}
public enum OAuth2_Authentication
{
    [StringValue("OAuth2/CallBack")]
    CALL_BACK
}
public enum OIDC_Authentication
{
    [StringValue("OIDC/CallBack")]
    CALL_BACK
}
public enum Google_Authentication
{
    [StringValue("https://accounts.google.com/o/oauth2/v2/auth")]
    AUTHORIZE_URL,

    [StringValue("OAuth/GoogleCallBack")]
    CALL_BACK,

    [StringValue("openid profile email")]
    SCOPE
}

public enum LinkedIn_Authentication
{
    [StringValue("https://www.linkedin.com/oauth/v2/authorization")]
    AUTHORIZE_URL,

    [StringValue("OAuth/LinkedInCallBack")]
    CALL_BACK,

    [StringValue("r_liteprofile r_emailaddress")]
    SCOPE
}

public enum Sales_Force_Authentication
{
    [StringValue("https://login.salesforce.com/services/oauth2/authorize")]
    AUTHORIZE_URL,

    [StringValue("OAuth/SFCallBack")]
    CALL_BACK
}

public enum Commitment_Type_Indication
{
    [StringValue("https://uri.etsi.org/01903/v1.2.2/#ProofOfOrigin.")]
    PROOF_OF_ORIGIN,

    [StringValue("https://uri.etsi.org/01903/v1.2.2/#ProofOfReceipt.")]
    PROOF_OF_RECEIPT,

    [StringValue("https://uri.etsi.org/01903/v1.2.2/#ProofOfDelivery.")]
    PROOF_OF_DELIVERY,

    [StringValue("https://uri.etsi.org/01903/v1.2.2/#ProofOfSender.")]
    PROOF_OF_SENDER,

    [StringValue("https://uri.etsi.org/01903/v1.2.2/#ProofOfApproval.")]
    PROOF_OF_APPROVAL,

    [StringValue("https://uri.etsi.org/01903/v1.2.2/#ProofOfCreation.")]
    PROOF_OF_CREATION
}

public enum TimeDuration
{
    COMMON_DAY,
    COMMON_DAYS,
    COMMON_HOUR,
    COMMON_HOURS,
    COMMON_MINUTE,
    COMMON_MINUTES,
    COMMON_AND
}

public enum DOCUMENT_RECALL_OPTION
{
    [StringValue("1")]
    ALL = 1,
    [StringValue("2")]
    PENDING = 2
}