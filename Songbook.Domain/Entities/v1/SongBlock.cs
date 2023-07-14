using System;
namespace Songbook.Domain.Entities.v1
{
	public class SongBlock
	{
		public Guid Id { get; set; }
		public Guid SongInfoId { get; set; }
		public required string SongBlockTypeId { get; set; }
		public int PositionInSong { get; set; }

		public required SongInfo SongInfo { get; set; }
		public required ICollection<SongRow> SongRows { get; set; }
		public required SongBlockType SongBlockType { get; set; }
	}
}

