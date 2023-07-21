using System;
using Songbook.Domain.DTOs.v1.Songs;
using Songbook.Domain.Entities.v1;

namespace Songbook.Domain.Services.v1
{
    public interface ISongService
    {
        string? CreateContentPreview(ICollection<SongBlock> songBlocks);
        Task CreateSongContentAsync(Guid songId, string content);
    }
}

