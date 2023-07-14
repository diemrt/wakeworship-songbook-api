using System;
namespace Songbook.Domain.Entities.v1
{
	public class SongRow
	{
		public Guid Id { get; set; }
		public DateTime InsertDate { get; set; }
		public Guid SongBlockId { get; set; }
		public int PositionInBlock { get; set; }

		public required SongBlock SongBlock { get; set; }
		public required ICollection<PhraseChord> PhraseChords { get; set; }
	}
}

