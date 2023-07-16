using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
	public class SongRowConfiguration : IEntityTypeConfiguration<SongRow>
    {
        public void Configure(EntityTypeBuilder<SongRow> builder)
        {
            builder.ToTable("song_row", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder.Property(p => p.InsertDate)
                .HasColumnName("insert_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();

            builder.Property(p => p.SongBlockId)
                .HasColumnName("song_block_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.PositionInBlock)
                .HasColumnName("position_in_block")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(p => p.SongBlock)
                .WithMany(p => p.SongRows)
                .HasForeignKey(p => p.SongBlockId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

