namespace Domain.Entities;

public class SystemSetting : EntityBase
{
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public string AttributeDefaultValue { get; set; }
    public string FieldType { get; set; }
    public string GroupName { get; set; }
    public int SortOrder { get; set; }
}