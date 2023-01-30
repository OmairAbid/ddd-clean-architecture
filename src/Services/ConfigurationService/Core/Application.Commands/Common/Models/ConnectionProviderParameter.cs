using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Common.Models;
public class ConnectionProviderParameter
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
