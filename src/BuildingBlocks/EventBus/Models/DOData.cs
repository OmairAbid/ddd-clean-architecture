namespace EventBus.Models
{
    public class DOData
    {
        #region Public Constructors

        public DOData(string Key, string Value, bool Visible, int Order)
        {
            this.Order = Order;
            this.Visible = Visible;
            this.Value = Value;
            this.Key = Key;
            data = new List<DOData>();
        }

        public DOData(string Key, string Value, string Type = "")
        {
            this.Value = Value;
            this.Key = Key;
            this.Type = Type;
            data = new List<DOData>();
        }

        public DOData()
        {
            data = new List<DOData>();
            Key = string.Empty;
            Value = string.Empty;
            Type = string.Empty;
        }

        #endregion Public Constructors

        #region Public Properties

        public string CertificateBase64 { set; get; }
        public List<DOData> data { set; get; }
        public string Key { set; get; }
        public int Order { set; get; }
        public string ProcessedState { set; get; }
        public string Type { set; get; }
        public string Value { set; get; }
        public bool Visible { set; get; }

        #endregion Public Properties
    }
}