using System;
using Songbook.Domain.Entities.v1.Common;

namespace Songbook.Domain.Entities.v1
{
	public class ChordType : BasicSetupType
    {
		public required string Id { get; set; }

		public required ICollection<PhraseChord> PhraseChords { get; set; }
        public required ICollection<Song> Songs { get; set; }
    }
}

