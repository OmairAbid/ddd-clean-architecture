using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.ORM.EntityConfigurations;
public class ProfileDetailEntityConfiguration : IEntityTypeConfiguration<ProfileDetail>
{
    public void Configure(EntityTypeBuilder<ProfileDetail> builder)
    {
        var p = builder;

        p.ToTable(nameof(ProfileDetail).ToUpper());

        PropertyInfo[] properties = typeof(ProfileDetail).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.Name != nameof(ProfileDetail.ProfileDetailValue))
            {
                p.Property(property.Name)
            .HasColumnName(property.Name.ToUpper());
            }

        }
    }
}
