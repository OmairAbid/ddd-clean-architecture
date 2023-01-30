using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.ORM.EntityConfigurations;
public class ProfileDetailValueEntityConfiguration : IEntityTypeConfiguration<ProfileDetailValue>
{
    public void Configure(EntityTypeBuilder<ProfileDetailValue> builder)
    {
        var p = builder;

        p.ToTable(nameof(ProfileDetailValue).ToUpper());

        p.HasKey(nameof(ProfileDetailValue.AttributeName),
                 nameof(ProfileDetailValue.AttributeValue));

        PropertyInfo[] properties = typeof(ProfileDetailValue).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            p.Property(property.Name)
            .HasColumnName(property.Name.ToUpper());
        }
    }
}
