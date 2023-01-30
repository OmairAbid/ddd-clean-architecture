using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Connector: EntityBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Name { get; set; }
    public string Provider { get; set; }
    public string Identifier { get; set; }
    public int Status { get; set; }
    public virtual ICollection<ConnectorDetail> ConnectorDetail { get; set; }
}
