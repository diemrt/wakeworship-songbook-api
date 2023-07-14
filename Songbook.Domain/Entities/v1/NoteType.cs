using System;
using Songbook.Domain.Entities.v1.Common;

namespace Songbook.Domain.Entities.v1
{
	public class NoteType : BasicSetupType
    {
		public required string Id { get; set; }
	}
}

