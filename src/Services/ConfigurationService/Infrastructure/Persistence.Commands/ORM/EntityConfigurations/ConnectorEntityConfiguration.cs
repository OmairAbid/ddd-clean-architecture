using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.ORM.EntityConfigurations;
public class ConnectorEntityConfiguration : IEntityTypeConfiguration<Connector>
{
    public void Configure(EntityTypeBuilder<Connector> builder)
    {
        var p = builder;

        p.ToTable(nameof(Connector).ToUpper());

        
        p.Property(entity => entity.Provider)
            .HasColumnName(nameof(Connector.Provider).ToUpper());
        p.Property(entity => entity.Id)
            .HasColumnName(nameof(Connector.Id).ToUpper());
        p.Property(entity => entity.CreatedBy)
            .HasColumnName(nameof(Connector.CreatedBy).ToUpper());
        p.Property(entity => entity.HMAC)
            .HasColumnName(nameof(Connector.HMAC).ToUpper());
        p.Property(entity => entity.CreatedOn)
            .HasColumnName(nameof(Connector.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedOn)
            .HasColumnName(nameof(Connector.LastModifiedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy)
            .HasColumnName(nameof(Connector.LastModifiedBy).ToUpper());
        p.Property(entity => entity.Status)
            .HasColumnName(nameof(Connector.Status).ToUpper());
        p.Property(entity => entity.Name)
            .HasColumnName(nameof(Connector.Name).ToUpper());
        p.Property(entity => entity.Identifier)
            .HasColumnName(nameof(Connector.Identifier).ToUpper());
    }
}
