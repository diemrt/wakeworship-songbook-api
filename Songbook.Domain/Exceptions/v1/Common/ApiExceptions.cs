using System;
using System.Net;

namespace Songbook.Domain.Exceptions.v1.Common
{
    public class ApiExceptions
    {
        public required ApiErrors ApiError { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public string? Path { get; set; }
    }
}

