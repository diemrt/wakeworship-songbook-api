using System;
using System.Net;
using AutoMapper;
using MediatR;
using Songbook.Domain.Exceptions.v1.Common;
using Songbook.Domain.Exceptions.v1.Messages;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Response.v1.Common;
using Songbook.Domain.Response.v1.Songs;

namespace Songbook.Infrastructure.MediatR.v1.Queries.Songs
{
	public class GetSongByIdQuery : IRequest<GenericResponse<GetSongByIdResponse>>
	{
		public GetSongByIdQuery(Guid id)
		{
            Id = id;
        }

        public Guid Id { get; }
    }

    public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, GenericResponse<GetSongByIdResponse>>
    {
        private readonly IMapper mapper;
        private readonly ISongRepository songRepository;
        private readonly IChordTypeRepository chordTypeRepository;

        public GetSongByIdQueryHandler(
            IMapper mapper,
            ISongRepository songRepository,
            IChordTypeRepository chordTypeRepository
            )
        {
            this.mapper = mapper;
            this.songRepository = songRepository;
            this.chordTypeRepository = chordTypeRepository;
        }

        public async Task<GenericResponse<GetSongByIdResponse>> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var chordTypes = await chordTypeRepository.GetAllAsync();
            var song = await songRepository.GetByIdAsync(request.Id);
            if(song == null)
                throw new GenericApiException(GenericSongErrorMessages.SONG_NOT_FOUND) { Code = (int)HttpStatusCode.InternalServerError };

            var data = mapper.Map<GetSongByIdResponse>(song);

            var result = new GenericResponse<GetSongByIdResponse>() { Data = data };
            return result;
        }
    }
}

