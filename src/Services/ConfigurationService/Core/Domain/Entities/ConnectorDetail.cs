using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ConnectorDetail:EntityBase
{
    public string ConnectorId { get; set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public string FieldType { get; set; }
    public int Type { get; set; }
}
