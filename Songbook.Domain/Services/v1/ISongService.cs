using System;
using Songbook.Domain.DTOs.v1.Songs;

namespace Songbook.Domain.Services.v1
{
    public interface ISongService
    {
        Task CreateSongContentAsync(Guid songId, string content);
    }
}

