using System;

namespace Songbook.Domain.Entities.v1
{
	public class SongBlockType
	{ 
		public required string Id { get; set; }
        public required string DisplayName { get; set; }
        public DateTime InsertDate { get; set; }

        public required ICollection<SongBlock> SongBlocks { get; set; }
	}
}

