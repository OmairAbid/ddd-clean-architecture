namespace Persistence.Commands.ORM.EntityConfigurations;

public class AdministratorLogDetailEntityConfiguration : IEntityTypeConfiguration<AdministratorLogDetail>
{
    #region Public Methods

    public void Configure(EntityTypeBuilder<AdministratorLogDetail> builder)
    {
        var p = builder;

        p.ToTable(nameof(AdministratorLogDetail).ToUpper());
        p.Property(entity => entity.AdministratorLogId)
                .HasColumnName(nameof(AdministratorLogDetail.AdministratorLogId).ToUpper());
        p.Property(entity => entity.Detail)
            .HasColumnName(nameof(AdministratorLogDetail.Detail).ToUpper());
        p.Property(entity => entity.CreatedBy)
            .HasColumnName(nameof(AdministratorLogDetail.CreatedBy).ToUpper());
        p.Property(entity => entity.HMAC)
            .HasColumnName(nameof(AdministratorLogDetail.HMAC).ToUpper());
        p.Property(entity => entity.CreatedOn)
            .HasColumnName(nameof(AdministratorLogDetail.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedOn)
            .HasColumnName(nameof(AdministratorLogDetail.LastModifiedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy)
            .HasColumnName(nameof(AdministratorLogDetail.LastModifiedBy).ToUpper());
        p.Property(entity => entity.Id)
           .HasColumnName(nameof(AdministratorLogDetail.Id).ToUpper());
    }

    #endregion Public Methods
}