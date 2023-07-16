using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class PhraseChordConfiguration : IEntityTypeConfiguration<PhraseChord>
    {
        public void Configure(EntityTypeBuilder<PhraseChord> builder)
        {
            builder.ToTable("phrase_chord", SongbookContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder.Property(p => p.SongRowId)
                .HasColumnName("song_row_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.ChordTypeId)
                .HasColumnName("chord_type_id")
                .HasColumnType("nvarchar(16)")
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(p => p.Phrase)
                .HasColumnName("phrase")
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            builder.Property(p => p.PositionInRow)
                .HasColumnName("position_in_row")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.InsertDate)
                .HasColumnName("insert_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();

            builder.HasOne(p => p.ChordType)
                .WithMany(p => p.PhraseChords)
                .HasForeignKey(p => p.ChordTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SongRow)
                .WithMany(p => p.PhraseChords)
                .HasForeignKey(p => p.SongRowId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

