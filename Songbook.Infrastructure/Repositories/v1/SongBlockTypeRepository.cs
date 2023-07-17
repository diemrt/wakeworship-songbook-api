using System;
using Microsoft.EntityFrameworkCore;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1;
using Songbook.Infrastructure.Repositories.v1.Common;

namespace Songbook.Infrastructure.Repositories.v1
{
	public class SongBlockTypeRepository : GenericRepo<SongBlockType>, ISongBlockTypeRepository
	{
        public SongBlockTypeRepository(SongbookContext context) : base(context)
        {

        }

        public async Task<IEnumerable<SongBlockType>> GetAllAsync()
        {
            var result = await _context.SongBlockTypes
                .AsNoTracking()
                .OrderBy(k => k.Id)
                .ToListAsync();

            return result;
        }
    }
}

