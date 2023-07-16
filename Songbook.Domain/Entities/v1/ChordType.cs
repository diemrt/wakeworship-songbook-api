using System;

namespace Songbook.Domain.Entities.v1
{
	public class ChordType
    {
		public required string Id { get; set; }
        public required string DisplayName { get; set; }
        public DateTime InsertDate { get; set; }

        public required ICollection<PhraseChord> PhraseChords { get; set; }
        public required ICollection<Song> Songs { get; set; }
    }
}

