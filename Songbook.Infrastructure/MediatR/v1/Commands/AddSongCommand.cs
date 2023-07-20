using System;
using AutoMapper;
using MediatR;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Requests.v1;
using Songbook.Domain.Response.v1.Common;

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

        public AddSongCommandHandler(
            IMapper mapper,
            ISongRepository songRepository
            )
        {
            this._mapper = mapper;
            this._songRepository = songRepository;
        }

        public async Task<GenericResponse<Guid>> Handle(AddSongCommand request, CancellationToken cancellationToken)
        {
            Guid song = await CreateSongEntityAsync(request);
            return new GenericResponse<Guid>() { Data = song };
        }

        private async Task<Guid> CreateSongEntityAsync(AddSongCommand request)
        {
            Domain.Entities.v1.Song song = _mapper.Map<Domain.Entities.v1.Song>(request.Request);
            var addSong = _songRepository.Create(song);
            await _songRepository.UnitOfWork.SaveChangesAsync();
            return addSong.Id;
        }
    }
}

