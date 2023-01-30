namespace Domain.Entities;

public partial class AdministratorLogDetail : EntityBase
{
    #region Public Properties

    public long AdministratorLogId { get; set; }
    public string? Detail { get; set; }

    #endregion Public Properties
}