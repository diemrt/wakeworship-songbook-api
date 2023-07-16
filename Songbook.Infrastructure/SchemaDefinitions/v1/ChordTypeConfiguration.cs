using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class ChordTypeConfiguration : IEntityTypeConfiguration<ChordType>
    {
        public void Configure(EntityTypeBuilder<ChordType> builder)
        {
            builder.ToTable("chord_type", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16)
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

