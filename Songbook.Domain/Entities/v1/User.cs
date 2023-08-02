using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songbook.Domain.Entities.v1
{
    public class User
    {
        public bool Enabled { get; set; }
        public DateTime InsertDate { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
        public string Username { get; set; }

    }
}
