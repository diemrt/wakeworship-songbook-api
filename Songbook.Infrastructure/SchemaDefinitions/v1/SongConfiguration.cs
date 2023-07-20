using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
	public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("song", SongbookContext.DEFAULT_SCHEMA);
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

            builder.Property(p => p.Title)
                .HasColumnName("title")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Content)
                .HasColumnName("content")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(p => p.Key)
                .HasColumnName("key")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(p => p.Capo)
                .HasColumnName("capo")
                .HasColumnType("int");

            builder.HasOne(p => p.ChordType)
                .WithMany(p => p.Songs)
                .HasForeignKey(p => p.Key)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

