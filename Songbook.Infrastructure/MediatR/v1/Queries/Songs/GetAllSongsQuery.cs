using System;
using AutoMapper;
using MediatR;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Response.v1.Common;
using Songbook.Domain.Response.v1.Songs;
using Songbook.Domain.Services.v1;

namespace Songbook.Infrastructure.MediatR.v1.Queries.Songs
{
	public class GetAllSongsQuery : IRequest<GenericCollectionResponse<GetAllSongsResponse>>
	{
		public GetAllSongsQuery()
		{
		}
	}

    public class GetAllSongsQueryHandler : IRequestHandler<GetAllSongsQuery, GenericCollectionResponse<GetAllSongsResponse>>
    {
        private readonly IMapper mapper;
        private readonly ISongService songService;
        private readonly ISongRepository songRepository;
        private readonly IChordTypeRepository chordTypeRepository;

        public GetAllSongsQueryHandler(
            IMapper mapper,
            ISongService songService,
            ISongRepository songRepository,
            IChordTypeRepository chordTypeRepository
            )
        {
            this.mapper = mapper;
            this.songService = songService;
            this.songRepository = songRepository;
            this.chordTypeRepository = chordTypeRepository;
        }

        public async Task<GenericCollectionResponse<GetAllSongsResponse>> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
        {
            var result = new GenericCollectionResponse<GetAllSongsResponse>() { Data = new List<GetAllSongsResponse>() };
            var songs = await songRepository.GetAllAsync();

            foreach (var song in songs)
            {
                var songResponse = mapper.Map<GetAllSongsResponse>(song);
                songResponse.Key = (await chordTypeRepository.GetByIdAsync(song.Key)).DisplayName;
                songResponse.ContentPreview = songService.CreateContentPreview(song.SongBlocks);
                result.Data.Add(songResponse);
            }
            result.Count = songs.Count();
            result.Page = 1;
            result.Pages = 1;

            return result;
        }
    }
}

