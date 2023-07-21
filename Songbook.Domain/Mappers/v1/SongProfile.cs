using System;
using AutoMapper;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Requests.v1;
using Songbook.Domain.Response.v1.Common;
using Songbook.Domain.Response.v1.Songs;

namespace Songbook.Domain.Mappers.v1
{
	public class SongProfile : Profile
	{
		public SongProfile()
        {
            #region GetAllSongsQuery
            CreateMap<Song, GetAllSongsResponse>()
                .ForMember(m => m.SongId, opt => opt.MapFrom(src => src.Id))
                .ForMember(m => m.Key, opt => opt.MapFrom(src => src.ChordType.DisplayName))
                .ForMember(m => m.Capo, opt => opt.MapFrom(src => src.Capo == null || src.Capo == 0 ? "No" : $"{src.Capo}th"))
                ;
            #endregion

            #region AddSongCommand
            CreateMap<AddEditSongRequest, Song>()
                .ForMember(m => m.Key, opt => opt.MapFrom(src => src.Key.Value))
                .ForMember(m => m.Capo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Capo) ? int.Parse(src.Capo) : 0 ))
                ;
            CreateMap<Guid, SongBlock>()
                        .ForMember(m => m.SongId, opt => opt.MapFrom(src => src))
                        ;
            CreateMap<Guid, SongRow>()
                .ForMember(m => m.SongBlockId, opt => opt.MapFrom(src => src))
                ;
            CreateMap<Guid, PhraseChord>()
                .ForMember(m => m.SongRowId, opt => opt.MapFrom(src => src))
                ;
            #endregion
        }

    }
}

