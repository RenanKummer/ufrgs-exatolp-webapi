﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ufrgs.ExatoLP.Domain.Entities;

namespace Ufrgs.ExatoLP.Infrastructure.Database.Entities;

public abstract class UpdatableEntityConfig<TEntity> : EntityBaseConfig<TEntity> where TEntity : UpdatableEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(entity => entity.UpdateDate).HasColumnName("update_date");

        builder.HasOne(entity => entity.UpdatedBy)
            .WithMany()
            .HasForeignKey("updated_by")
            .OnDelete(DeleteBehavior.Restrict);

    }
}
