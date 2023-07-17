using System;
using AutoMapper;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Response.v1;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Domain.Mappers.v1
{
	public class FormItemsProfile : Profile
	{
		public FormItemsProfile()
		{
			CreateMap<ChordType, GenericItemResponse<string>>()
				.ForMember(m => m.Label, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(m => m.Value, opt => opt.MapFrom(src => src.Id))
                ;

            CreateMap<SongBlockType, GenericItemResponse<string>>()
                .ForMember(m => m.Label, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(m => m.Value, opt => opt.MapFrom(src => src.Id))
                ;
        }
	}
}

