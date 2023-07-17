using System;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Domain.Response.v1
{
	public class GetFormItemsResponse
	{
		public IEnumerable<GenericItemResponse<string>>? ChordTypeItems { get; set; }
        public IEnumerable<GenericItemResponse<string>>? SongBlockItems { get; set; }
    }
}

