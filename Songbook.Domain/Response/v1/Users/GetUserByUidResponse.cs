using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songbook.Domain.Response.v1.Users
{
    public class GetUserByUidResponse
    {
        public Guid Id { get; set; }
        public string Uid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
