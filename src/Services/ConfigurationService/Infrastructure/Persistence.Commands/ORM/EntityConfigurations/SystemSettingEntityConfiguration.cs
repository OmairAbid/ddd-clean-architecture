using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.ORM.EntityConfigurations;
public class SystemSettingEntityConfiguration : IEntityTypeConfiguration<SystemSetting>
{
    public void Configure(EntityTypeBuilder<SystemSetting> builder)
    {
        var p = builder;

        p.ToTable(nameof(SystemSetting).ToUpper());

        p.Property(entity => entity.AttributeName)
            .HasColumnName(nameof(SystemSetting.AttributeName).ToUpper());
        p.Property(entity => entity.AttributeValue)
            .HasColumnName(nameof(SystemSetting.AttributeValue).ToUpper());
        p.Property(entity => entity.AttributeDefaultValue)
            .HasColumnName(nameof(SystemSetting.AttributeDefaultValue).ToUpper());
        p.Property(entity => entity.FieldType)
            .HasColumnName(nameof(SystemSetting.FieldType).ToUpper());
        p.Property(entity => entity.Id)
            .HasColumnName(nameof(SystemSetting.Id).ToUpper());
        p.Property(entity => entity.GroupName)
            .HasColumnName(nameof(SystemSetting.GroupName).ToUpper());
        p.Property(entity => entity.CreatedBy)
            .HasColumnName(nameof(SystemSetting.CreatedBy).ToUpper());
        p.Property(entity => entity.HMAC)
            .HasColumnName(nameof(SystemSetting.HMAC).ToUpper());
        p.Property(entity => entity.CreatedOn)
            .HasColumnName(nameof(SystemSetting.CreatedOn).ToUpper());
        p.Property(entity => entity.LastModifiedOn)
            .HasColumnName(nameof(SystemSetting.LastModifiedOn).ToUpper());
        p.Property(entity => entity.LastModifiedBy)
            .HasColumnName(nameof(SystemSetting.LastModifiedBy).ToUpper());
        p.Property(entity => entity.SortOrder)
            .HasColumnName(nameof(SystemSetting.SortOrder).ToUpper());

    }
}
