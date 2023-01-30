namespace EventBus.Models
{
    public class AuditDelta
    {
        #region Public Properties

        public List<AuditDetailDelta> AuditDetail { get; set; }
        public string DisplayHeaderKey { get; set; }
        public string DisplayKey { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsTranslate { get; set; }
        public string ValueAfter { get; set; }
        public string ValueBefore { get; set; }

        #endregion Public Properties
    }

    public class AuditDetailDelta
    {
        #region Public Properties

        public string DisplayKey { get; set; }
        public string FieldName { get; set; }
        public string ValueAfter { get; set; }
        public string ValueBefore { get; set; }

        #endregion Public Properties
    }
}