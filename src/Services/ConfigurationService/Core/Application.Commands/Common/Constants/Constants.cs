using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Common.Constants;
public class BrandingLevel
{
    #region Public Properties

    public string BrandName { get; set; }
    public string BrandValue { get; set; }

    #endregion Public Properties
}

public class ActionOrder
{
    public string Name { get; set; }
    public int Order { get; set; }
}

public static class Constants
{
    #region Public Fields

    public const string ADMIN_LOGO_FOLDER_PATH = @"Content\themes\adocs\images\sh-Logo-enhanced.png";
    public const string ADOCS_VERSION_FILE_PATH = @"signinghub.version.xml";

    /// <summary>
    /// Constant key for ADSS certification service postfix
    /// </summary>
    public const string ADSS_CERTIFICATION_SERVICE_POSTFIX = "/adss/certification/csi";
    public const string ADSS_ORGANIZATION_CERTIFICATE_POSTFIX = "/adss/signing/hcert";
    public const string ADSS_SIGNATURE_VERIFICATION_POSTFIX = "/adss/verification/hsvi";

    public const string ADSS_VERIFICATION_SERVICE_POSTFIX = "/adss/verification/dss";
    public const string ALPHABETS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string API_TAG_ACCOUNT_MANAGEMENT = "Account Management";
    public const string API_TAG_APPENDIX = "Appendix";
    public const string API_TAG_AUTHENTICATION = "Authentication";
    public const string API_TAG_COUNTRY_LIST = "Country List";
    public const string API_TAG_DOCUMENT_PACKAGE = "Document Package";
    public const string API_TAG_DOCUMENT_PREPARATION = "Document Preparation";
    public const string API_TAG_DOCUMENT_PROCESSING = "Document Processing";
    public const string API_TAG_DOCUMENT_WORKFLOW = "Document Workflow";
    public const string API_TAG_ENTERPRISE_MANAGEMENT = "Enterprise Management";
    public const string API_TAG_GENERAL = "General";
    public const string API_TAG_GETTING_STARTED = "Getting Started";
    public const string API_TAG_INTRODUCTION = "Introduction";
    public const string API_TAG_LANGUAGES = "Languages";
    public const string API_TAG_LOOSE_INTEGRATION = "Loose Integration";
    public const string API_TAG_PERSONAL_SETTINGS = "Personal Settings";
    public const string API_TAG_PREREQUISITES = "Prerequisites";
    public const string API_TAG_SIGNINGHUB_ADMIN_APIS = "SigningHub Admin APIs";
    public const string API_TAG_TIGHT_INTEGRATION = "Tight Integration";
    public const string API_TAG_QUICK_INTEGRATION = "Quick Integration";
    public const string API_TAG_ACCESS_TOKENS = "Access Tokens";
    public const string API_TAG_TIMEZONE_LIST = "Timezone List";
    public const string API_TAG_UPDATES = "Updates";
    public const string API_TAG_WELCOME = "Welcome";
    public const string API_TAG_V3_VS_V4 = "Migration";

    /// <summary>
    /// Audit log comparer returns this value in case of empty value
    /// </summary>
    public const string AUDIT_LOG_EMPTY_VALUE = "(null)";

    public const string BILLING_PAYMENT_INVOICE_TEMPLATE_PATH = @"Scripts\app\billing\templates\";
    public const string COMPANY_LOGO_PATH = @"Content\CompanyLogo\company_logo.jpg";
    public const string DEFAULT_API_REQUEST_MODELS_NAMESPACE = "SigningHub.API.Models.V7";
    public const string DEFAULT_AVATAR_PATH = @"\Content\themes\adocs\images\Verification-avator.png";
    public const string DEFAULT_DOCUMENT_PATH = @"Content\Welcome to SigningHub.pdf";
    public const string DEFAULT_FAVICON_FILE_PATH = FAVICON_FOLDER_PATH + FAVICON_FILE_NAME;
    public const string DEFAULT_WEB_REQUEST_MODELS_NAMESPACE = "SigningHub.Infrastructure.DataModels";
    public const string DEFAULT_WITNESS_REASON_VALUE = "Witnessing " + WITNESS_REASON_VARIABLE;
    public const string DEFAULTS_JSON_PATH = @"Scripts\app\languages\default\";
    public const string DIGITS = "0123456789";
    public const string EMAILS_JSON_pATH = @"Scripts\app\languages\emails\";
    public const string EMAILS_JSON_PATH = @"Scripts\app\languages\emails\";
    public const string EMAILS_TEMPLATE_JSON_FOLDER_NAME = @"EmailTemplates\";
    public const string ENTERPRISE_LOGO_FOLDER_PATH = @"Content/themes/adocs/images/enterprise-logos";
    public const string FAVICON_ADMIN_FOLDER_PATH = @"Content/themes/adocs/images/";
    public const string FAVICON_FILE_NAME = "SH-favicon.ico";
    public const string FAVICON_FOLDER_PATH = @"Content/themes/adocs/images/favicon/";
    public const string FONTS_PATH = @"Content\fonts";
    public const string IIS_USER_GROUP = @"BUILTIN\IIS_IUSRS";
    public const string LANGUAGES_JSON_PATH = @"Scripts\app\languages\";
    public const string PERSONAL_LOGO_FOLDER_PATH = @"Content\themes\adocs\images\";
    public const string REDIS_CACHE_SIGNINGHUB_ADOCS_BRANDING_KEY = "SystemBrandingBranding";
    public const string PROFILE_LOGO_FOLDER_PATH = @"Content/themes/adocs/images/authentication-profile";

    /// <summary>
    /// Constant key for branding in Redis Cache server
    /// </summary>
    public const string REDIS_CACHE_SIGNINGHUB_ENTERPRISE_BRANDING_KEY = "EnterpriseBranding";

    public const string REDIS_CACHE_SIGNINGHUB_ENTERPRISE_BRANDINGS_LIST_KEY = "EnterpriseBrandings";
    public const string REDIS_CACHE_SIGNINGHUB_REDIS_KEY = "SigningHubCache";
    public const string SIGNATURE_APPEARANCE_PATH = @"Content\appearances";

    /// <summary>
    /// Constant key for signature appearence in Redis Cache server
    /// </summary>
    public const string SIGNATURE_APPEARENCE_REDIS_KEY = "SIGNATURE_APPEARENCE";

    public const string SPECIALCHARACTERS = "!@#$%^&*?.,/';:|`~<>()+=_\\-";
    public const string STRIPE_SERVICEPLAN_FILNAME = @"ServicePlan_StripePlan_mapping.json";
    public const string SYSTEM_EMAILS_FILE_NAME = @"SystemEmails.json";
    public const string TEMP_DIRECTORY_PATH = @"Temp";

    /// <summary>
    /// Constant key for text fonts in Redis Cache server
    /// </summary>
    public const string TEXT_FONTS_REDIS_KEY = "TEXT_FONTS";

    /// <summary>
    /// Constant key for web supported languages in Redis Cache server
    /// </summary>
    public const string WEB_SUPPORTED_LANGUAGES_REDIS_KEY = "WEB_SUPPORTED_LANGUAGES";

    /// <summary>
    /// Constant key for supported languages in Redis Cache server
    /// </summary>
    public const string SUPPORTED_LANGUAGES_REDIS_KEY = "SUPPORTED_LANGUAGES";

    public const string TRANSPARENT_IMAGE_PATH = @"Content\themes\adocs\images\transparent.png";
    public const string USER_EMAILS_FILE_NAME = @"UserEmails.json";
    public const string WITNESS_REASON_VARIABLE = "[USER_NAME]";
    public const string PDF_SIGNATURE_VERIFICATION_REQUEST_ID = "SIGNINGHUB_VERIFICATION_REQUEST";
    public const string XML_SIGNATURE_VERIFICATION_REQUEST_ID = "XML_DigSign_Enveloped_RT-C1_S1-1024-C1";
    public const string WORD_SIGNATURE_VERIFICATION_REQUEST_ID = "ASCERTIA_DOCS_WORD_VERIFICATION";

    public static readonly string[] SupportedDateFormats = { "m/d", "m/d/yy", "m/d/yyyy", "mm/dd/yy", "mm/dd/yyyy", "mm/yy", "mm/yyyy", "d-mmm", "d-mmm-yy", "d-mmm-yyyy", "dd-mmm-yy", "dd-mmm-yyyy", "yy-mm-dd", "yyyy-mm-dd", "mmm-yy", "mmm-yyyy", "mmmm-yy", "mmmm-yyyy", "mmm d, yyyy", "mmmm d, yyyy", "dd/mm/yy", "ddmmmyyyy" };

    public const string DEFAULT_PASSWORD_ASTERISKS = "******";

    public static List<string> DefaultFontSize
    {
        get
        {
            return new List<string>() { "8", "10", "12", "14", "16", "18", "20" };
        }
    }

    public static List<string> CacheKeys
    {
        get
        {
            return new List<string>() { "SystemSetting", "ServicePlan", "Connector", "Profile", "TermAndCondition", "ConnectionProvider", TEXT_FONTS_REDIS_KEY, SIGNATURE_APPEARENCE_REDIS_KEY };
        }
    }

    public static List<string> AllowedTypes
    {
        get
        {
            return new List<string>()
                {
                "pdf", "docx", "doc", "xls", "xlsx", "ppt", "pptx", "odt","rtf", "txt", "ods", "csv", "tsv", "png", "ico","jpg", "jpeg", "gif", "tif", "tiff", "emf", "bmp","dot", "docm", "dotm",
                    "dotx", "ott", "rtf", "xlsm","xlsb", "xltx", "pcl", "mht", "svg", "xps", "tex","cgm", "epub", "pot", "pps", "potx", "ppsx", "odp","pptm","dxf","dwg","xltm","html","xhtml",
                    "vsd","vsdx","vss","vst","vsx","vtx","vdw","vdx","vssx","vstx","vsdm","vssm","vstm","psd","mpp","mpt","one","xml","fo","msg","eml"
                };
        }
    }

    public static List<string> DefaultFontFamily
    {
        get
        {
            return new List<string>() { "COURIER", "HELVETICA" };
        }
    }

    public static List<string> ICCProfileCMYK
    {
        get
        {
            return new List<string>() { "CMYK", "DeviceCMYK", "DefaultCMYK", "U.S. Web Coated (SWOP) v2", "Web Coated SWOP Grade 5 Paper", "Web Coated SWOP Grade 3 Paper", "GRACol 2006 (ISO 12647-2:2004)", "Web Uncoated v2 Coated", "Web Coated (SWOP) v2", "Japan Web Coated (Ad)", "Japan Color 2003 Web Coated", "Japan Color 2002 Newspaper", "Japan Color 2001 Coated", "Coated FOGRA39 (ISO 12647-2:2004)", "Uncoated FOGRA29 (ISO 12647-2:2004)", "Web Coated FOGRA28 (ISO 12647-2:2004)", "Coated FOGRA27 (ISO 12647-2:2004)" };
        }
    }

    public static List<string> ICCProfileRGB
    {
        get
        {
            return new List<string>() { "RGB", "SRGB", "DEVICERGB", "DEFAULTRGB", "SMPTE-C", "PAL/SECAM", "HDTV", "SDTV", "NTSC", "PAL", "SDTV PAL", "SDTV NTSC" };
        }
    }

    public static List<string> BlackListCharacters
    {
        get
        {
            return new List<string>() { "@", "=", "0x09", "0x0D" };
        }
    }

    #endregion Public Fields

    #region Public Properties

    public static List<BrandingLevel> DefaultBranding
    {
        get
        {
            return new List<BrandingLevel>()
                {
                    new BrandingLevel {BrandName = "level1", BrandValue = "#232323"},
                    new BrandingLevel {BrandName = "level2", BrandValue = "#55cf31"},
                    new BrandingLevel {BrandName = "level3", BrandValue = "#e03500"},
                    new BrandingLevel {BrandName = "level4", BrandValue = "#f9da00"},
                    new BrandingLevel {BrandName = "level5", BrandValue = "#ffffff"},
                    new BrandingLevel {BrandName = "level6", BrandValue = "#797979"},
                    new BrandingLevel {BrandName = "level7", BrandValue = "#ffb600"},
                    new  BrandingLevel{BrandName = "level8", BrandValue = "#f9da00"},
                    new BrandingLevel {BrandName = "level9", BrandValue = "#b3b3b3"},
                    new BrandingLevel {BrandName = "level10", BrandValue = "#2f2f2f"},
                    new BrandingLevel {BrandName = "level11", BrandValue = "#007aff"},
                    new BrandingLevel {BrandName = "level12", BrandValue = "#ccf1c1"},
                    new BrandingLevel {BrandName = "level13", BrandValue = "#eda240"}
                };
        }
    }

    public static List<ActionOrder> APIOrderActions
    {
        get
        {
            return new List<ActionOrder>()
                {
                    //Authentication
                    new ActionOrder {Name = "/authenticate ", Order = 1},//client_credentials
                    new ActionOrder {Name = "/authenticate", Order = 2},
                    new ActionOrder {Name = "/v4/authenticate/scope", Order = 3},
                    new ActionOrder {Name = "/authenticate/kerberos", Order = 4},
                    new ActionOrder {Name = "/authenticate/sso", Order = 5},
                    new ActionOrder {Name = "/v4/authentication/otp", Order = 6},
                    new ActionOrder {Name = "/authenticate/pre", Order = 7},
                    new ActionOrder {Name = "/v4/terms", Order = 8},
                    new ActionOrder {Name = "/v4/system/configurations/profiles/auth", Order = 9},
                      new  ActionOrder{Name = "/tokens", Order = 10},
                    new  ActionOrder{Name = "/v4/logout", Order = 11},
                 

                    //Enterprise Management
                    new ActionOrder {Name = "/v4/enterprise/users", Order = 1},
                    new ActionOrder {Name = "/v4/enterprise/users", Order = 2},
                    new ActionOrder {Name = "/v4/enterprise/users", Order = 3},
                    new ActionOrder {Name = "/v4/enterprise/users", Order = 4},
                    new ActionOrder {Name = "/v4/enterprise/signingcertificates", Order = 5},
                    new ActionOrder {Name = "/v4/enterprise/signingcertificates/{usercertificateid}", Order = 6},
                    new ActionOrder {Name = "/v4/enterprise/signingcertificates/{usercertificateid}", Order = 7},
                    new ActionOrder {Name = "/v4/enterprise/invitations/{pageNo}/{recordsPerPage}", Order = 8},
                    new ActionOrder {Name = "/v4/enterprise/invitations", Order = 9},
                    new ActionOrder {Name = "/v4/enterprise/invitations", Order = 10},
                    new ActionOrder {Name = "/v4/enterprise/invitations", Order = 11},
                    new ActionOrder {Name = "/v4/settings/groups/{recordPerPage}/{pageNo}", Order = 12},
                    new ActionOrder {Name = "/v4/enterprise/groups/{id}", Order = 13},
                    new ActionOrder {Name = "/v4/enterprise/groups/{id}", Order = 14},
                    new ActionOrder {Name = "/v4/enterprise/groups/{id}", Order = 15},
                    new ActionOrder {Name = "/v4/enterprise/groups", Order = 16},
                    new ActionOrder {Name = "/v4/enterprise/branding", Order = 17},
                    new ActionOrder {Name = "/v4/enterprise/branding/logo", Order = 18},
                    new ActionOrder {Name = "/v4/enterprise/branding/favicon", Order = 19},
                    new ActionOrder {Name = "/v4/enterprise/notifications/email/reset", Order = 20},
                    new ActionOrder {Name = "/v4/enterprise/packages/{document_status}/{page_no:int}/{records_per_page:int}", Order = 21},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}", Order = 22},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}", Order = 23},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}/workflow/users", Order = 24},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}/workflow/{order:int}/placeholder", Order = 25},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}/workflow/{order:int}/group", Order = 26},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}/workflow/{order:int}/group", Order = 27},
                    new ActionOrder {Name = "/v4/enterprise/legal_notices/{id}", Order = 28},
                    new ActionOrder {Name = "/v4/enterprise/legal_notices/{id}", Order = 29},
                    new ActionOrder {Name = "/v4/enterprise/legal_notices", Order = 30},
                    new ActionOrder {Name = "/v4/enterprise/packages/{packageId:long}/complete", Order = 31}
                };
        }
    }

    public static class DbSource
    {
        public static string SQL => "SQL";
        public static string ORACLE => "ORACLE";
    }

    public static class DatabaseStaticData
    {
        public static string ADMIN => "ADMIN";
        public static string HMAC => "HMAC";
    }

    #endregion Public Properties
}
