using System;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Domain.Response.v1.Songs
{
	public class GetSongByIdResponse
	{
        public Guid SongId { get; set; }
        public string? Title { get; set; }
        public GenericItemResponse<string>? Key { get; set; }
        public string? Capo { get; set; }
        public required ICollection<GetSongByIdSongBlockResponse> SongBlocks { get; set; }
    }

    public class GetSongByIdSongBlockResponse
    {
        public Guid SongBlockId { get; set; }
        public GenericItemResponse<string>? SongBlockTypeItem { get; set; }
        public required ICollection<GetSongByIdSongRowResponse> SongRows { get; set; }
    }

    public class GetSongByIdSongRowResponse
    {
        public Guid SongRowId { get; set; }
        public required ICollection<GetSongByIdPhraseChordResponse> PhraseChords { get; set; }
    }

    public class GetSongByIdPhraseChordResponse
    {
        public Guid PhraseChordId { get; set; }
        public GenericItemResponse<string>? ChordTypeItem { get; set; }
        public string? Phrase { get; set; }
    }
}

