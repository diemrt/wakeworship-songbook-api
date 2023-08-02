using System;
using Microsoft.EntityFrameworkCore;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1;
using Songbook.Infrastructure.Repositories.v1.Common;

namespace Songbook.Infrastructure.Repositories.v1
{
    public class UserRepository : GenericRepo<User>, IUserRepository
    {
        public UserRepository(SongbookContext context) : base(context)
        {
        }

        public async Task<User> GetByUidAsync(string uid)
        {
            var result = await _context.Users
                .Where(u => u.Uid == uid)
                .AsNoTracking()
                .FirstAsync();

            return result;
        }
    }
}

