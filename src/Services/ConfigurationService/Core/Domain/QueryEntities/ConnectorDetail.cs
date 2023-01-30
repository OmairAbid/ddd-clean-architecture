using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;
public class ConnectorDetail
{
    public string ConnectorId { get; set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public string FieldType { get; set; }
    public int Type { get; set; }
    public long Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string HMAC { get; set; }
    public int? SortOrder { get; set; }
}
