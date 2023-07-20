using System;
using AutoMapper;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Requests.v1;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Domain.Mappers.v1
{
	public class SongProfile : Profile
	{
		public SongProfile()
		{
            CreateMap<AddEditSongRequest, Song>()
                .ForMember(m => m.Key, opt => opt.MapFrom(src => src.Key.Value))
                ;
        }
	}
}

