﻿using System;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1.Common;

namespace Songbook.Domain.Repositories.v1
{
    public interface IUserRepository : IGenericRepo<User>
    {
        Task<User> GetByUidAsync(string uid);
    }
}

