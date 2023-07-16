using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1.Common;

namespace Songbook.Infrastructure.SchemaDefinitions.v1.Common
{
	public class BasicSetupTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BasicSetupType
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.DisplayName)
                .HasColumnName("display_name")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(182)
                .IsRequired();

            builder.Property(p => p.InsertDate)
                .HasColumnName("insert_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();
        }
    }
}

