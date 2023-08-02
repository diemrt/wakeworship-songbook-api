using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Songbook.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songbook.Infrastructure.SchemaDefinitions.v1
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", SongbookContext.DEFAULT_SCHEMA);

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

            builder.Property(p => p.Uid)
                .HasColumnName("uid")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Username)
                .HasColumnName("username")
                .HasColumnType("nvarchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Enabled)
                .HasColumnName("enabled")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
