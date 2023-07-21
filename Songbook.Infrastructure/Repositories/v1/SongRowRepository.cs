using System;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1;
using Songbook.Infrastructure.Repositories.v1.Common;

namespace Songbook.Infrastructure.Repositories.v1
{
    public class SongRowRepository : GenericRepo<SongRow>, ISongRowRepository
    {
        public SongRowRepository(SongbookContext context) : base(context)
        {
        }
    }
}

