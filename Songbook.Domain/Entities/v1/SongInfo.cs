using System;
namespace Songbook.Domain.Entities.v1
{
	public class SongInfo
	{
		public Guid Id { get; set; }
		public required string Title { get; set; }
		public required string Key { get; set; }
		public int Capo { get; set; }

		public required ICollection<SongBlock> SongBlocks { get; set; }
	}
}

