using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;

[Serializable]
public class ConnectionProvider
{
    public long Id { get; set; }
   
    public string AttributeName { get; set; }
    /// <summary>
    /// Possible values are 0 = NO, 1 = YES
    /// </summary>
    public int IsForADSS { get; set; }
    public string AttributeKey { get; set; }
    /// <summary>
    /// Possible values are 0, 1 (ENABLED = 1, DISABLED = 0)
    /// </summary>
    public int Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string HMAC { get; set; }
    public List<ConnectionProviderParameter> ConnectionProviderParameter { get; set; }
    public List<ConnectionProviderDetail> ConnectionProviderDetail { get; set; }
    public List<string> Purposes { get; set; }
}
