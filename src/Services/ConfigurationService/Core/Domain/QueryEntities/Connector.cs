using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;
public class Connector
{
    public long Id { get;  set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string HMAC { get; set; }
    public string Name { get; set; }
    public string Provider { get; set; }
    public string Identifier { get; set; }
    public int Status { get; set; }
    public IEnumerable<ConnectorDetail> ConnectorDetail { get; set; }
    public bool IsForADSS { get; set; }
    public string Purpose { get; set; }
    public string Type { get; set; }
    public List<string> Purposes { get; set; }
    public List<KeyValuePair<string, string>> PurposesAndTypes { get; set; }
}
