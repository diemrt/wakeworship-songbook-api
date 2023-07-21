using System;
using Microsoft.EntityFrameworkCore;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1;
using Songbook.Infrastructure.Repositories.v1.Common;

namespace Songbook.Infrastructure.Repositories.v1
{
    public class SongRepository : GenericRepo<Song>, ISongRepository
    {
        public SongRepository(SongbookContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            var result = await _context.Songs
                .AsNoTracking()
                .Include(t => t.SongBlocks)
                .ThenInclude(t => t.SongRows)
                .ThenInclude(t => t.PhraseChords)
                .OrderBy(k => k.Title)
                .ToListAsync();

            return result;
        }

        public override async Task<Song?> GetByIdAsync(Guid id)
        {
            var result = await _context.Songs
                .AsNoTracking()
                .Include(t => t.SongBlocks)
                .ThenInclude(t => t.SongRows)
                .ThenInclude(t => t.PhraseChords)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}

