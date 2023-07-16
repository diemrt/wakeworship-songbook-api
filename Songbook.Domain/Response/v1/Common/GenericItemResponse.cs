using System;
namespace Songbook.Domain.Response.v1.Common
{
	public class GenericItemResponse<T>
	{
        public required string Label { get; set; }
        public required T Value { get; set; }
    }
}

