using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;
public class Currency
{
    public string Name { get; set; }
    /// <summary>
    /// Currency code
    /// </summary>
    public string Code { get; set; }
    public int Status { get; set; }
    public string HMAC { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}
