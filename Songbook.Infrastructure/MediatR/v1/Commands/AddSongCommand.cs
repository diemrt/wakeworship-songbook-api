using System;
using System.Net;
using AutoMapper;
using MediatR;
using Songbook.Domain.DTOs.v1.Songs;
using Songbook.Domain.Exceptions.v1.Common;
using Songbook.Domain.Exceptions.v1.Messages;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Requests.v1;
using Songbook.Domain.Response.v1.Common;
using Songbook.Domain.Services.v1;
using Songbook.Infrastructure.Services.v1.Utils;

namespace Songbook.Infrastructure.MediatR.v1.Commands
{
	public class AddSongCommand : IRequest<GenericResponse<Guid>>
	{
		public AddSongCommand(AddEditSongRequest request)
		{
            Request = request;
        }

        public AddEditSongRequest Request { get; }
    }

    public class AddSongCommandHandler : IRequestHandler<AddSongCommand, GenericResponse<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;
        private readonly ISongService _songService;

        public AddSongCommandHandler(
            IMapper mapper,
            ISongRepository songRepository,
            ISongService songService
            )
        {
            this._mapper = mapper;
            this._songRepository = songRepository;
            this._songService = songService;
        }

        public async Task<GenericResponse<Guid>> Handle(AddSongCommand request, CancellationToken cancellationToken)
        {
            Guid songId = await CreateSongEntityAsync(request);
            await CreateSongContentAsync(songId, request.Request.Content);
            return new GenericResponse<Guid>() { Data = songId };
        }

        private async Task CreateSongContentAsync(Guid songId, string content)
        {
            var deserializedSongBlocks = SongUtilsService.CreateSongParts(content, "(", ")");
            foreach (var deserialized in deserializedSongBlocks.Select((value, i) => new { i, value }))
            {
                var songBlock = _mapper.Map<Domain.Entities.v1.SongBlock>(songId);
                songBlock.PositionInSong = deserialized.i;
                songBlock.SongBlockTypeId = deserialized.value.BeforeDelimiter ?? "";
#warning Ultimare la creazione del metodo!
            }
            throw new NotImplementedException();
        }

        private async Task<Guid> CreateSongEntityAsync(AddSongCommand request)
        {
            var song = _mapper.Map<Domain.Entities.v1.Song>(request.Request);
            var addSong = _songRepository.Create(song);
            await _songRepository.UnitOfWork.SaveChangesAsync();
            return addSong.Id;
        }
    }
}

