using System;
namespace Songbook.Domain.Response.v1.Common
{
    public class GenericResponse<T>
    {
        public T? Data { get; set; }
    }

    public class GenericCollectionResponse<T>
    {
        public required List<T> Data { get; set; }
        public int? Page { get; set; }
        public int Pages { get; set; }
        public int Count { get; set; }
    }
}

