using System;
namespace Songbook.Domain.Entities.v1
{
	public class PhraseChord
	{
		public Guid Id { get; set; }
		public Guid SongRowId { get; set; }
		public required string ChordTypeId { get; set; }
		public string? Phrase { get; set; }
		public int PositionInRow { get; set; }
		public DateTime InsertDate { get; set; }

		public required ChordType ChordType { get; set; }
		public required SongRow SongRow { get; set; }
	}
}

