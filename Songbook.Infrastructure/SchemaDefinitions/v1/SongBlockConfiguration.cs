using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class SongBlockConfiguration : IEntityTypeConfiguration<SongBlock>
    {
        public void Configure(EntityTypeBuilder<SongBlock> builder)
        {
            builder.ToTable("song_block", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder.Property(p => p.SongId)
                .HasColumnName("song_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.SongBlockTypeId)
                .HasColumnName("song_block_type_id")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.PositionInSong)
                .HasColumnName("position_in_song")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.InsertDate)
                .HasColumnName("insert_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();

            builder.HasOne(p => p.Song)
                .WithMany(p => p.SongBlocks)
                .HasForeignKey(p => p.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SongBlockType)
                .WithMany(p => p.SongBlocks)
                .HasForeignKey(p => p.SongBlockTypeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

