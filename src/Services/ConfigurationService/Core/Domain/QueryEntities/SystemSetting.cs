using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;
public class SystemSetting
{
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public string AttributeDefaultValue { get; set; }
    public string FieldType { get; set; }
    public string GroupName { get; set; }
    public int? SortOrder { get; set; }
    public string HMAC { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public long Id { get; set; }
    public List<SystemSettingsDetails> AttributeChoices = new List<SystemSettingsDetails>();
}
