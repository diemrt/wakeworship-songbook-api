using System;
using AutoMapper;
using MediatR;
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

        public GetSongByIdQueryHandler(
            IMapper mapper,
            ISongRepository songRepository
            )
        {
            this.mapper = mapper;
            this.songRepository = songRepository;
        }

        public async Task<GenericResponse<GetSongByIdResponse>> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<GenericResponse<GetSongByIdResponse>>(request.Id);
            var song = await songRepository.GetByIdAsync(request.Id);
            throw new NotImplementedException();
        }
    }
}

