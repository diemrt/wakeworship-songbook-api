using AutoMapper;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Response.v1.Common;
using Songbook.Domain.Response.v1.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songbook.Domain.Mappers.v1
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region GetUserByUidQuery
            CreateMap<User,GetUserByUidResponse>()
                ;
            #endregion
        }
    }
}
