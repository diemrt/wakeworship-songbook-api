using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Songbook.Domain.DTOs.v1.Songs;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Exceptions.v1.Common;
using Songbook.Domain.Exceptions.v1.Messages;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Services.v1;
using Songbook.Infrastructure.Services.v1.Utils;

namespace Songbook.Infrastructure.Services.v1
{
    public class SongService : ISongService
    {
        private readonly IMapper mapper;
        private readonly ISongBlockRepository songBlockRepository;
        private readonly ISongRowRepository songRowRepository;
        private readonly IPhraseChordRepository phraseChordRepository;

        public SongService(
            IMapper mapper,
            ISongBlockRepository songBlockRepository,
            ISongRowRepository songRowRepository,
            IPhraseChordRepository phraseChordRepository
            )
        {
            this.mapper = mapper;
            this.songBlockRepository = songBlockRepository;
            this.songRowRepository = songRowRepository;
            this.phraseChordRepository = phraseChordRepository;
        }

        public async Task CreateSongContentAsync(Guid songId, string content)
        {
            try
            {
                var deserializedSongBlocks = SongUtilsService.CreateSongParts(content, "(", ")");
                await CreateSongBlockPartsAsync(songId, deserializedSongBlocks);
            }
            catch (Exception ex)
            {
                throw new GenericApiException($"{SongReaderServiceErrorMessages.CONTENT_CREATION} Usare il seguente id per la verifica: '{songId}'.") { Code = (int)HttpStatusCode.InternalServerError };
            }
        }

        private async Task CreateSongBlockPartsAsync(Guid songId, IEnumerable<GenericStringItemDTO> deserializedSongBlocks)
        {
            foreach (var deserialized in deserializedSongBlocks.Select((value, i) => new { i, value }))
            {
                var entity = mapper.Map<SongBlock>(songId);
                entity.PositionInSong = deserialized.i;
                entity.SongBlockTypeId = deserialized.value.BeforeDelimiter ?? "";
                var addEntity = songBlockRepository.Create(entity);
                await songBlockRepository.UnitOfWork.SaveChangesAsync();

                var deserializedSongRows = SongUtilsService.CreateSongParts(deserialized.value.AfterDelimiter ?? "", ";");
                await CreateSongRowPartsAsync(addEntity.Id, deserializedSongRows);
            }
        }

        private async Task CreateSongRowPartsAsync(Guid blockId, IEnumerable<GenericStringItemDTO> deserializedSongRows)
        {
            foreach (var deserialized in deserializedSongRows.Select((value, i) => new { i, value }))
            {
                var entity = mapper.Map<SongRow>(blockId);
                entity.PositionInBlock = deserialized.i;
                var addEntity = songRowRepository.Create(entity);
                await songRowRepository.UnitOfWork.SaveChangesAsync();

                var deserializedPhraseChords = SongUtilsService.CreateSongParts(deserialized.value.AfterDelimiter ?? "", "[", "]");
                await CreatePhraseChordsPartsAsync(addEntity.Id, deserializedPhraseChords);
            }
        }

        private async Task CreatePhraseChordsPartsAsync(Guid rowId, IEnumerable<GenericStringItemDTO> deserializedPhraseChords)
        {
            foreach (var deserialized in deserializedPhraseChords.Select((value, i) => new { i, value }))
            {
                var entity = mapper.Map<PhraseChord>(rowId);
                entity.PositionInRow = deserialized.i;
                entity.ChordTypeId = deserialized.value.BeforeDelimiter ?? "";
                entity.Phrase = deserialized.value.AfterDelimiter;

                var addEntity = phraseChordRepository.Create(entity);
                await phraseChordRepository.UnitOfWork.SaveChangesAsync();
            }
        }

        public string CreateContentPreview(ICollection<SongBlock> songBlocks)
        {
            var phrases = songBlocks
                .SelectMany(s => s.SongRows)
                .SelectMany(s => s.PhraseChords)
                .Where(p => !string.IsNullOrEmpty(p.Phrase))
                .ToList()
                ;
            var phrase = string.Join(" ", phrases.Select(s => s.Phrase));
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            phrase = regex.Replace(phrase, " ");
            return phrase;
        }
    }
}

