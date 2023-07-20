using System;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Domain.Requests.v1
{
	public class AddEditSongRequest
	{
		public required string Title { get; set; }
		public required int Capo { get; set; }
		public required GenericItemResponse<string>  Key { get; set; }
		public required string Song { get; set; }

        //verse)Questo è il[c] testo di una[a] canzone[none];Cosa te ne [g]pare[none]#chours)Bello![g]
    }
}

