using System;
namespace Songbook.Domain.Entities.v1
{
	public class SongRow
	{
		public Guid Id { get; set; }
		public DateTime InsertDate { get; set; }
		public Guid PhraseChordId { get; set; }
		public int PositionInBlock { get; set; }
	}
}

