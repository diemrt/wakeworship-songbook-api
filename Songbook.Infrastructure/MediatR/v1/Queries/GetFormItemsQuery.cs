using System;
using AutoMapper;
using MediatR;
using Songbook.Domain.Repositories.v1;
using Songbook.Domain.Response.v1;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Infrastructure.MediatR.v1.Queries
{
	public class GetFormItemsQuery : IRequest<GenericResponse<GetFormItemsResponse>>
	{
		public GetFormItemsQuery()
		{
		}
	}

    public class GetFormItemsQueryHandler : IRequestHandler<GetFormItemsQuery, GenericResponse<GetFormItemsResponse>>
    {
        private readonly IChordTypeRepository _chordTypeRepository;
        private readonly ISongBlockTypeRepository _songBlockTypeRepository;
        private readonly IMapper _mapper;

        public GetFormItemsQueryHandler(
            IChordTypeRepository chordTypeRepository
            ,ISongBlockTypeRepository songBlockTypeRepository
            ,IMapper mapper
            )
        {
            this._chordTypeRepository = chordTypeRepository;
            this._songBlockTypeRepository = songBlockTypeRepository;
            this._mapper = mapper;
        }

        public async Task<GenericResponse<GetFormItemsResponse>> Handle(GetFormItemsQuery request, CancellationToken cancellationToken)
        {
            var result = new GenericResponse<GetFormItemsResponse>() { Data = new GetFormItemsResponse() };
            var chordTypes = await _chordTypeRepository.GetAllAsync();
            var songBlockTypes = await _songBlockTypeRepository.GetAllAsync();

            result.Data.ChordTypeItems = _mapper.Map<IEnumerable<GenericItemResponse<string>>>(chordTypes);
            result.Data.SongBlockItems = _mapper.Map<IEnumerable<GenericItemResponse<string>>>(songBlockTypes);

            return result;
        }
    }
}

