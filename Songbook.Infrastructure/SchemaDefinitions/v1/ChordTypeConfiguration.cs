using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;
using Songbook.Infrastructure.SchemaDefinitions.v1.Common;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class ChordTypeConfiguration : BasicSetupTypeConfiguration<ChordType>
    {
        public override void Configure(EntityTypeBuilder<ChordType> builder)
        {
            builder.ToTable("chord_type", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16)
                .IsRequired();
        }
    }
}

