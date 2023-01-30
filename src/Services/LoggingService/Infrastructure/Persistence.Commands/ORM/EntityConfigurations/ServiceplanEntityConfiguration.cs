namespace Persistence.Commands.ORM.EntityConfigurations;

public class ServiceplanEntityConfiguration : IEntityTypeConfiguration<Serviceplan>
{
    #region Public Methods

    public void Configure(EntityTypeBuilder<Serviceplan> builder)
    {
        var p = builder;

        p.ToTable(nameof(Serviceplan).ToUpper());

        p.Property(entity => entity.Id).HasColumnName(nameof(Serviceplan.Id).ToUpper());
        p.Property(entity => entity.Name).HasColumnName(nameof(Serviceplan.Name).ToUpper());
        p.Property(entity => entity.Type).HasColumnName(nameof(Serviceplan.Type).ToUpper());
        p.Property(entity => entity.BillingModel).HasColumnName(nameof(Serviceplan.BillingModel).ToUpper());
        p.Property(entity => entity.IsPublic).HasColumnName(nameof(Serviceplan.IsPublic).ToUpper());
        p.Property(entity => entity.Price).HasColumnName(nameof(Serviceplan.Price).ToUpper());
        p.Property(entity => entity.ValidaityPeriod).HasColumnName(nameof(Serviceplan.ValidaityPeriod).ToUpper());
        p.Property(entity => entity.Signatures).HasColumnName(nameof(Serviceplan.Signatures).ToUpper());
        p.Property(entity => entity.DiskSpace).HasColumnName(nameof(Serviceplan.DiskSpace).ToUpper());
        p.Property(entity => entity.UploadSize).HasColumnName(nameof(Serviceplan.UploadSize).ToUpper());
        p.Property(entity => entity.Templates).HasColumnName(nameof(Serviceplan.Templates).ToUpper());
        p.Property(entity => entity.DocumentsShare).HasColumnName(nameof(Serviceplan.DocumentsShare).ToUpper());
        p.Property(entity => entity.Users).HasColumnName(nameof(Serviceplan.Users).ToUpper());
        p.Property(entity => entity.DefaultVerificationProfile).HasColumnName(nameof(Serviceplan.DefaultVerificationProfile).ToUpper());
        p.Property(entity => entity.SMTPConnector).HasColumnName(nameof(Serviceplan.SMTPConnector).ToUpper());
        p.Property(entity => entity.OTPConnector).HasColumnName(nameof(Serviceplan.OTPConnector).ToUpper());
        p.Property(entity => entity.Status).HasColumnName(nameof(Serviceplan.Status).ToUpper());
        p.Property(entity => entity.HMAC).HasColumnName(nameof(Serviceplan.HMAC).ToUpper());
        p.Property(entity => entity.CreatedBy).HasColumnName(nameof(Serviceplan.CreatedBy).ToUpper());
        p.Property(entity => entity.CreatedOn).HasColumnName(nameof(Serviceplan.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy).HasColumnName(nameof(Serviceplan.LastModifiedBy).ToUpper());
        p.Property(entity => entity.LastModifiedOn).HasColumnName(nameof(Serviceplan.LastModifiedOn).ToUpper());
        p.Property(entity => entity.YearlyPrice).HasColumnName(nameof(Serviceplan.YearlyPrice).ToUpper());
        p.Property(entity => entity.PaymentType).HasColumnName(nameof(Serviceplan.PaymentType).ToUpper());
        p.Property(entity => entity.IsMonthly).HasColumnName(nameof(Serviceplan.IsMonthly).ToUpper());
        p.Property(entity => entity.IsYearly).HasColumnName(nameof(Serviceplan.IsYearly).ToUpper());
        p.Property(entity => entity.DefaultRemoteAuthorizeProfile).HasColumnName(nameof(Serviceplan.DefaultRemoteAuthorizeProfile).ToUpper());
        p.Property(entity => entity.DocumentLog).HasColumnName(nameof(Serviceplan.DocumentLog).ToUpper());
        p.Property(entity => entity.DefaultAuthenticationProfile).HasColumnName(nameof(Serviceplan.DefaultAuthenticationProfile).ToUpper());
        p.Property(entity => entity.IsAutoReset).HasColumnName(nameof(Serviceplan.IsAutoReset).ToUpper());
        p.Property(entity => entity.IsPasswordRequired).HasColumnName(nameof(Serviceplan.IsPasswordRequired).ToUpper());
        p.Property(entity => entity.IsPdfACompliant).HasColumnName(nameof(Serviceplan.IsPdfACompliant).ToUpper());
        p.Property(entity => entity.SimpleESignatures).HasColumnName(nameof(Serviceplan.SimpleESignatures).ToUpper());
    }

    #endregion Public Methods
}