using System;
namespace Songbook.Domain.Entities.v1
{
	public class SongBlock
	{
		public Guid Id { get; set; }
		public Guid SongInfoId { get; set; }
		public Guid SongRowId { get; set; }
		public required string SongBlockId { get; set; }
		public int PositionInSong { get; set; }
	}
}

