using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class SongBlockTypeConfiguration : IEntityTypeConfiguration<SongBlockType>
    {
        public void Configure(EntityTypeBuilder<SongBlockType> builder)
        {
            builder.ToTable("song_block_type", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32)
                .IsRequired();

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

