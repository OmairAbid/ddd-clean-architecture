namespace Persistence.Commands.ORM.EntityConfigurations;

public class AdministratorLogEntityConfiguration : IEntityTypeConfiguration<AdministratorLog>
{
    #region Public Methods

    public void Configure(EntityTypeBuilder<AdministratorLog> builder)
    {
        var p = builder;

        p.ToTable(nameof(AdministratorLog).ToUpper());

        p.Property(entity => entity.InfoKey)
            .HasColumnName(nameof(AdministratorLog.InfoKey).ToUpper());
        p.Property(entity => entity.InfoValue)
            .HasColumnName(nameof(AdministratorLog.InfoValue).ToUpper());
        p.Property(entity => entity.Agent)
            .HasColumnName(nameof(AdministratorLog.Agent).ToUpper());
        p.Property(entity => entity.AgentDetail)
            .HasColumnName(nameof(AdministratorLog.AgentDetail).ToUpper());
        p.Property(entity => entity.Id)
            .HasColumnName(nameof(AdministratorLog.Id).ToUpper());
        p.Property(entity => entity.Action)
            .HasColumnName(nameof(AdministratorLog.Action).ToUpper());
        p.Property(entity => entity.CreatedBy)
            .HasColumnName(nameof(AdministratorLog.CreatedBy).ToUpper());
        p.Property(entity => entity.HMAC)
            .HasColumnName(nameof(AdministratorLog.HMAC).ToUpper());
        p.Property(entity => entity.CreatedOn)
            .HasColumnName(nameof(AdministratorLog.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedOn)
            .HasColumnName(nameof(AdministratorLog.LastModifiedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy)
            .HasColumnName(nameof(AdministratorLog.LastModifiedBy).ToUpper());
        p.Property(entity => entity.Module)
            .HasColumnName(nameof(AdministratorLog.Module).ToUpper());
        p.Property(entity => entity.Detail)
    .HasColumnName(nameof(AdministratorLog.Detail).ToUpper());
        p.Property(entity => entity.AdministratorEmail)
    .HasColumnName(nameof(AdministratorLog.AdministratorEmail).ToUpper());
        p.Property(entity => entity.SubModule)
    .HasColumnName(nameof(AdministratorLog.SubModule).ToUpper());
    }

    #endregion Public Methods
}