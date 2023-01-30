using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Common.Models;

public class GetAllSystemSetting
{
    public long Id { get; protected set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public string AttributeDefaultValue { get; set; }
    public string FieldType { get; set; }
    public string GroupName { get; set; }
    public int SortOrder { get; set; }
}
