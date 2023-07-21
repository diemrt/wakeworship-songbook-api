using System;
namespace Songbook.Domain.Response.v1.Songs
{
	public class GetAllSongsResponse
	{
		public Guid SongId { get; set; }
		public required string Title { get; set; }
		public required string Key { get; set; }
		public required string Capo { get; set; }
		public string? ContentPreview { get; set; }
	}
}

