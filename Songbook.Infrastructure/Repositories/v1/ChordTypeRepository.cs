using System;
using Microsoft.EntityFrameworkCore;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1;
using Songbook.Infrastructure.Repositories.v1.Common;

namespace Songbook.Infrastructure.Repositories.v1
{
	public class ChordTypeRepository : GenericRepo<ChordType>, IChordTypeRepository
    {
        public ChordTypeRepository(SongbookContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ChordType>> GetAllAsync()
        {
            var result = await _context.ChordTypes
                .AsNoTracking()
                .OrderBy(k => k.Id)
                .ToListAsync();

            return result;
        }
    }
}

