﻿using System;
namespace Songbook.Domain.Entities.v1
{
	public class Song
	{
		public Guid Id { get; set; }
		public required string Title { get; set; }
		public required string Key { get; set; }
		public required string Content { get; set; }
		public int? Capo { get; set; }
		public DateTime InsertDate { get; set; }

		public required ICollection<SongBlock> SongBlocks { get; set; }
        public required ChordType ChordType { get; set; }
    }
}

