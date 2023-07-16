using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;
using Songbook.Infrastructure.SchemaDefinitions.v1.Common;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class SongBlockTypeConfiguration : BasicSetupTypeConfiguration<SongBlockType>
    {
        public override void Configure(EntityTypeBuilder<SongBlockType> builder)
        {
            builder.ToTable("song_block_type", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}

