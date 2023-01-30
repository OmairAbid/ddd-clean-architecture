using Application.Queries.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Common.Models;
public class ServicePlanQueryResponse
{
    #region Public Properties

    /// <summary>BillingType : Possible values are ONLINE_BILLING = 1, OFFLINE_BILLING = 2, NO_BILLING
    /// = 3, NO_BILLING_TRIAL = 4,.</summary>
    /// <value>The billing model.</value>
    public Int32 BillingModel { get; set; }

    /// <summary>Gets or sets who created this instance.</summary>
    /// <value>Describes who created this instance.</value>
    public String CreatedBy { get; set; }

    /// <summary>Gets or sets the Date/Time of the created on.</summary>
    /// <value>The created on.</value>
    public DateTime CreatedOn { get; set; }

    /// <summary>Gets or sets the default authentication profile.</summary>
    /// <value>The default authentication profile.</value>
    public Nullable<Int32> DefaultAuthenticationProfile { get; set; }

    /// <summary>Gets or sets the default verification profile.</summary>
    /// <value>The default verification profile.</value>
    public Int32 DefaultVerificationProfile { get; set; }

    /// <summary>0 = Unlimited, > 0 means limited, value in MB.</summary>
    /// <value>The disk space.</value>
    public Nullable<Double> DiskSpace { get; set; }

    /// <summary>Gets or sets the document hash algorithm.HashingAlgorithm : Possible values are SHA1, SHA256, SHA384, SHA512</summary>
    /// <value>The document hash algorithm.</value>
    public string DocumentHashAlgorithm { get; set; }

    /// <summary>Gets or sets the document log. DocumentLogType: Possible values are BASIC = 1, DETAILED = 2</summary>
    /// <value>The document log.</value>
    public Nullable<Int32> DocumentLog { get; set; }
    /// <summary>0 = Unlimited, > 0 means limited.</summary>
    /// <value>The documents share.</value>
    public Nullable<Int32> DocumentsShare { get; set; }

    /// <summary>Gets or sets the hmac.</summary>
    /// <value>The hmac.</value>
    public String HMAC { get; set; }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    public Int32 Id { get; set; }

    //public Nullable<Int32> DefaultRemoteAuthorizeProfile { get; set; }
    /// <summary>Service plan has 0 price having Billing Mode i.e. NOBILLING_TRIAL. Possible values
    /// are 0, 1 (1= ON, 0 = OFF)</summary>
    /// <value>The is automatic reset.</value>
    public Nullable<Int32> IsAutoReset { get; set; }

    /// <summary>Gets or sets the is monthly.</summary>
    /// <value>The is monthly.</value>
    public Nullable<Int32> IsMonthly { get; set; }
    /// <summary>Possible values are 0, 1 (0= Private, 1 = Public)</summary>
    /// <value>The is public.</value>
    public Int32 IsPublic { get; set; }

    /// <summary>Gets or sets the is yearly.</summary>
    /// <value>The is yearly.</value>
    public Nullable<Int32> IsYearly { get; set; }

    /// <summary>Gets or sets who last modified this instance.</summary>
    /// <value>Describes who last modified this instance.</value>
    public String LastModifiedBy { get; set; }

    /// <summary>Gets or sets the Date/Time of the last modified on.</summary>
    /// <value>The last modified on.</value>
    public DateTime LastModifiedOn { get; set; }

    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    public String Name { get; set; }

    /// <summary>Gets or sets the otp connector.</summary>
    /// <value>The otp connector.</value>
    public String OTPConnector { get; set; }

    /// <summary>PaymentType: possible values are 1 = Pay Regularly, 2 = Pay As You Go.</summary>
    /// <value>The type of the payment.</value>
    public Nullable<Int32> PaymentType { get; set; }

    /// <summary>Gets or sets the price.</summary>
    /// <value>The price.</value>
    public Nullable<Double> Price { get; set; }

    /// <summary>0 = Unlimited, > 0 means limited.</summary>
    /// <value>The signatures.</value>
    public Nullable<Int32> Signatures { get; set; }

    /// <summary>0 = Unlimited, > 0 means limited.</summary>
    /// <value>The simple electronic signatures.</value>
    public Nullable<Int32> SimpleESignatures { get; set; }

    /// <summary>Gets or sets the SMTP connector.</summary>
    /// <value>The SMTP connector.</value>
    public String SMTPConnector { get; set; }

    /// <summary>Possible values are 0, 1 (1 = ENABLED, 0 = DISABLED)</summary>
    /// <value>The status.</value>
    public Int32 Status { get; set; }

    /// <summary>0 = Unlimited, > 0 means limited.</summary>
    /// <value>The templates.</value>
    public Nullable<Int32> Templates { get; set; }

    /// <summary>ServicePlanType : Possible values are INDIVIDUAL = 1, ENTERPRISE = 2, NONE = 3.</summary>
    /// <value>The type.</value>
    public Int32 Type { get; set; }
    /// <summary>0 = Unlimited, > 0 means limited, value in MB.</summary>
    /// <value>The size of the upload.</value>
    public Nullable<Double> UploadSize { get; set; }

    /// <summary>0 = Unlimited, > 0 means limited.</summary>
    /// <value>The users.</value>
    public Nullable<Int32> Users { get; set; }

    /// <summary>Gets or sets the validaity period.</summary>
    /// <value>The validaity period.</value>
    public Nullable<Int32> ValidaityPeriod { get; set; }

    /// <summary>Gets or sets the yearly price.</summary>
    /// <value>The yearly price.</value>
    public Nullable<Double> YearlyPrice { get; set; }

    /// <summary>
    /// Changed the column Certificate OwnerShip to IsPasswordRequired
    /// </summary>
    public bool IsPasswordRequired { get; set; }

    /// <summary>
    /// Adds PDF/A compliant documents when checked
    /// </summary>
    public bool IsPdfACompliant { get; set; }

    public bool isT1CSigningEnabled { get; set; }

    public string T1CApiKey { get; set; }

    public Nullable<Int32> T1CKeyStore { get; set; }

    public string SignatureType { get; set; }

    public List<ServicePlanDetailQuery> ServicePlanDetail { get; set; }

    public string ServicePlanType { get; set; }

    public string ServicePlanPaymentType { get; set; }

    public string ServicePlanBillingModel { get; set; }

    public List<ServicePlanDetailQuery> ServicePlanDetailAttributes { get; set; }

    public string DefaultSigningProfileName { get; set; }

    public string DefaultVerificationProfileName { get; set; }

    public string DefaultCertificationProfileName { get; set; }
    public string DefaultWitnessSignProfileName { get; set; }

    public string DefaultRemoteAuthorizationProfileName { get; set; }

    public string DefaultCSPProfileName { get; set; }

    public List<Dictionary<string, string>> Fonts { get; set; }
    public SignatureSettingViewModal SignatureSetting { get; set; }
    public bool IsCSPEnabled { get; set; }
    public bool IsRAEnabled { get; set; }

    public ServicePlanQueryResponse()
    {
        ServicePlanDetail = new List<ServicePlanDetailQuery>();
    }

    #endregion Public Properties
}

public class ServicePlanDetailQuery
{
    public int Id { get; set; }
    public int ServicePlanId { get; set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
    public string HMAC { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    /// <summary>
    /// SERVICE_PLAN_DETAIL_TYPE: Possible values are  FEATURE, SETTING
    /// </summary>
    public string FieldType { get; set; }
    public int? SigningProfileID { get; set; }
}
