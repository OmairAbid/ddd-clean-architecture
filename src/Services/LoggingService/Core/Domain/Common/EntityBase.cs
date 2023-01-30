namespace Domain.Common;

public class EntityBase
{
    public long Id { get; protected set; }
    public string? CreatedBy { get; set; } = "SYSTEM";
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string? LastModifiedBy { get; set; } = "SYSTEM";
    public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;
    public string HMAC { get; set; } = "HMAC";
}