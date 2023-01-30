using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Profile : EntityBase
{
    public String Name { get; set; }

    public String Description { get; set; }
    /// <summary>
    /// ProfileType : Possible values are AUTHENTICATION = 1, SIGNING = 2, 
    /// VERIFICATION = 3, CERTIFICATION = 4, RA = 5
    /// </summary>
    public Int32 Type { get; set; }
    /// <summary>
    /// Status: Possible values are ENABLED = 1, DISABLED = 0, REMOVED = 2
    /// </summary>
    public Int32 Status { get; set; }
    public Int32 IsPrivate { get; set; }

    public virtual ICollection<ProfileDetail> ProfileDetail { get; set; }
}
