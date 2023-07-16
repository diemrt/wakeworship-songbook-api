using System;
using Songbook.Domain.Response.v1.Common;

namespace Songbook.Domain.Response.v1
{
	public class FormItemsResponse
	{
		public required IEnumerable<GenericItemResponse<string>> ChordTypeItems { get; set; }
        public required IEnumerable<GenericItemResponse<string>> SongBlockItems { get; set; }
    }
}

