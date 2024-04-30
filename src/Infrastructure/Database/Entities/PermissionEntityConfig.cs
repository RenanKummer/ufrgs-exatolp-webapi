﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ufrgs.ExatoLP.Core.Entities;
using Ufrgs.ExatoLP.Infrastructure.Database.Constants;

namespace Ufrgs.ExatoLP.Infrastructure.Database.Entities;

public class PermissionEntityConfig : UpdatableEntityConfig<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(permission => permission.Id);
        builder.HasIndex(permission => permission.Name).IsUnique();

        builder.Property(permission => permission.Id)
            .HasColumnName(PrimaryColumnNames.PermissionId)
            .ValueGeneratedOnAdd();

        builder.Property(permission => permission.Name).HasColumnName("permission_name").IsRequired();
        builder.Property(permission => permission.Description).HasColumnName("permission_description");

        base.Configure(builder);
    }
}
