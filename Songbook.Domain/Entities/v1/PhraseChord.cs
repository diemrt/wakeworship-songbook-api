using System;
namespace Songbook.Domain.Entities.v1
{
	public class PhraseChord
	{
		public Guid Id { get; set; }
		public required string NoteTypeId { get; set; }
		public string? Phrase { get; set; }
		public int PositionInRow { get; set; }
		public DateTime InsertDate { get; set; }
	}
}

