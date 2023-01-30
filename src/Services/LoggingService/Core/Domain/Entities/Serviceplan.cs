namespace Domain.Entities
{
    public class Serviceplan
    {
        #region Public Properties

        public int BillingModel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? DefaultAuthenticationProfile { get; set; }
        public int? DefaultRemoteAuthorizeProfile { get; set; }
        public int DefaultVerificationProfile { get; set; }
        public double? DiskSpace { get; set; }
        public int? DocumentLog { get; set; }
        public int? DocumentsShare { get; set; }
        public string HMAC { get; set; }
        public int Id { get; set; }
        public int? IsAutoReset { get; set; }
        public int? IsMonthly { get; set; }
        public bool IsPasswordRequired { get; set; }
        public bool? IsPdfACompliant { get; set; }
        public int IsPublic { get; set; }
        public int? IsYearly { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string Name { get; set; }
        public string? OTPConnector { get; set; }
        public int? PaymentType { get; set; }
        public double? Price { get; set; }
        public int? Signatures { get; set; }
        public int? SimpleESignatures { get; set; }
        public string? SMTPConnector { get; set; }
        public int Status { get; set; }
        public int? Templates { get; set; }
        public int Type { get; set; }
        public double? UploadSize { get; set; }
        public int? Users { get; set; }
        public int? ValidaityPeriod { get; set; }
        public double? YearlyPrice { get; set; }

        #endregion Public Properties
    }
}