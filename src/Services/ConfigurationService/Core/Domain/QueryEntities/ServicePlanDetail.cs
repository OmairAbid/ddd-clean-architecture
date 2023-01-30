using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryEntities;
public class ServicePlanDetail
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
