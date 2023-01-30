
namespace Persistence.Commands.ORM.EntityConfigurations;
public class ConnectorDetailEntityConfiguration : IEntityTypeConfiguration<ConnectorDetail>
{
    public void Configure(EntityTypeBuilder<ConnectorDetail> builder)
    {
        var p = builder;

        p.ToTable(nameof(ConnectorDetail).ToUpper());

        p.HasKey(nameof(ConnectorDetail.ConnectorId),nameof(ConnectorDetail.AttributeName));

        p.Property(entity => entity.AttributeValue)
            .HasColumnName(nameof(ConnectorDetail.AttributeValue).ToUpper());
        p.Property(entity => entity.AttributeName)
            .HasColumnName(nameof(ConnectorDetail.AttributeName).ToUpper());
        p.Property(entity => entity.ConnectorId)
            .HasColumnName(nameof(ConnectorDetail.ConnectorId).ToUpper());
        p.Property(entity => entity.Id)
            .HasColumnName(nameof(ConnectorDetail.Id).ToUpper());
        p.Property(entity => entity.FieldType)
            .HasColumnName(nameof(ConnectorDetail.FieldType).ToUpper());
        p.Property(entity => entity.CreatedBy)
            .HasColumnName(nameof(ConnectorDetail.CreatedBy).ToUpper());
        p.Property(entity => entity.HMAC)
            .HasColumnName(nameof(ConnectorDetail.HMAC).ToUpper());
        p.Property(entity => entity.CreatedOn)
            .HasColumnName(nameof(ConnectorDetail.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedOn)
            .HasColumnName(nameof(ConnectorDetail.LastModifiedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy)
            .HasColumnName(nameof(ConnectorDetail.LastModifiedBy).ToUpper());
        p.Property(entity => entity.Type)
            .HasColumnName(nameof(ConnectorDetail.Type).ToUpper());
    }
}
