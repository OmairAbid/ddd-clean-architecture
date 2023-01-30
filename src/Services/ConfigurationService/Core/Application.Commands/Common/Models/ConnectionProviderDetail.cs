using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Common.Models;
public class ConnectionProviderDetail
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
