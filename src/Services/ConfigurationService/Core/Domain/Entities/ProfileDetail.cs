using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileDetail : EntityBase
{
    /// <summary>
    /// May contains keys of ProfileConnector, ProfilesID, ProfileCommon Enum keys
    /// </summary>
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public virtual ICollection<ProfileDetailValue> ProfileDetailValue { get; set; }
}
