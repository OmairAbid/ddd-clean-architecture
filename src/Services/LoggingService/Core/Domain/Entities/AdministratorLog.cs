namespace Domain.Entities;

public partial class AdministratorLog : EntityBase
{
    #region Public Properties

    public string Action { get; set; }
    public string? AdministratorEmail { get; set; }
    public List<AdministratorLogDetail> AdministratorLogDetail { get; set; } = new List<AdministratorLogDetail>();
    public string? Agent { get; set; }
    public string AgentDetail { get; set; }
    public string Detail { get; set; }
    public string? InfoKey { get; set; }
    public string? InfoValue { get; set; }
    public string? Module { get; set; }
    public string? SubModule { get; set; }

    #endregion Public Properties
}