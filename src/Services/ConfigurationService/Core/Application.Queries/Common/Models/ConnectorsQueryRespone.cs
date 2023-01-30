

namespace Application.Queries.Common.Models;

public class ConnectorDetailsResponse
{
    /// <summary>
    /// Name of connector which is being used as primary key for connectors 
    /// </summary>
    public string ConnectorId { get; set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    /// <summary>
    /// Possible values are BUTTON, CHECKBOX, PASSWORD, PFX_FILE, RADIO, SAML_CERT_FILE, TEXT, XML_FILE, IMAGE
    /// </summary>
    public string FieldType { get; set; }
    /// <summary>
    /// RequestParameter : Possible value are HEADER_PARAMTER = 1, BODY_PARAMTER = 2
    /// </summary>
    public int Type { get; set; }
    public int? SortOrder { get; set; }
}

public class ConnectionProviderParameterResponse
{
    public int Id { get; set; }
    public int ConnectionProviderId { get; set; }
    public string AttributeKey { get; set; }
    public string AttributeValue { get; set; }
    /// <summary>
    /// Possible values are BUTTON, CHECKBOX, PASSWORD, PFX_FILE, RADIO, SAML_CERT_FILE, TEXT, XML_FILE
    /// </summary>
    public string FieldType { get; set; }
    public int? SortOrder { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string HMAC { get; set; }
    /// <summary>
    /// RequestParameter : Possible value are HEADER_PARAMTER = 1, BODY_PARAMTER = 2,
    /// </summary>
    public int Type { get; set; }
    public List<KeyValuePair<string, string>> AttributeChoices { get; set; }
}

public class ConnectionProviderDetailResponse
{
    public int ConnectionProviderId { get; set; }
    public string Purpose { get; set; }
    /// <summary>
    /// ConnectionProviderType : Possible values are PASSWORD, SSL_CLIENT, LOCAL, MOBILE, SERVER,
    /// ACTIVE_DIRECTORY, SALES_FORCE, INTEGRATION_GOOGLE_DRIVE, INTEGRATION_DROPBOX, OFFICE_365, ADFS, MARKETING,
    /// SAML_SP, INTEGRATION_ONEDRIVE, FIREBASE, MAXMIND, SECURITY, BANKID, ITSME
    /// </summary>
    public string Type { get; set; }
    public string Identifier { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string HMAC { get; set; }
}
