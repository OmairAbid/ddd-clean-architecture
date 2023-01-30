using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.ORM.EntityConfigurations;
public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        var p = builder;

        p.ToTable(nameof(Profile).ToUpper());

        PropertyInfo[] properties = typeof(Profile).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.Name != nameof(Profile.ProfileDetail))
            {
                p.Property(property.Name)
            .HasColumnName(property.Name.ToUpper());
            }
            
        }
    }
}
