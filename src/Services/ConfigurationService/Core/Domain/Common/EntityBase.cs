
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class EntityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; protected set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string HMAC { get; set; }
}
