namespace Persistence.Commands.ORM.EntityConfigurations;

public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
{
    #region Public Methods

    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        var p = builder;

        p.ToTable(nameof(Profile).ToUpper());
        p.Property(entity => entity.Id)
                .HasColumnName(nameof(Profile.Id).ToUpper());
        p.Property(entity => entity.Name)
            .HasColumnName(nameof(Profile.Name).ToUpper());
        p.Property(entity => entity.Description)
            .HasColumnName(nameof(Profile.Description).ToUpper());
        p.Property(entity => entity.Type)
            .HasColumnName(nameof(Profile.Type).ToUpper());
        p.Property(entity => entity.Status)
            .HasColumnName(nameof(Profile.Status).ToUpper());
        p.Property(entity => entity.CreatedBy)
            .HasColumnName(nameof(Profile.CreatedBy).ToUpper());
        p.Property(entity => entity.HMAC)
            .HasColumnName(nameof(Profile.HMAC).ToUpper());
        p.Property(entity => entity.CreatedOn)
            .HasColumnName(nameof(Profile.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedOn)
            .HasColumnName(nameof(Profile.LastModifiedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy)
            .HasColumnName(nameof(Profile.LastModifiedBy).ToUpper());
    }

    #endregion Public Methods
}