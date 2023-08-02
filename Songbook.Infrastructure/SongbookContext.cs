using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1.Common;

namespace Songbook.Infrastructure
{
	public class SongbookContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<ChordType> ChordTypes { get; set; }
        public DbSet<PhraseChord> PhraseChords { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongBlock> SongBlocks { get; set; }
        public DbSet<SongBlockType> SongBlockTypes { get; set; }
        public DbSet<SongRow> SongRows { get; set; }
        public DbSet<User> Users { get; set; }

        public SongbookContext(DbContextOptions<SongbookContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(builder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

