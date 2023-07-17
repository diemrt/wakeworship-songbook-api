using System;
using Newtonsoft.Json;

namespace Songbook.Domain.Exceptions.v1.Common
{
    [Serializable]
    public class GenericApiException : Exception
    {
        public GenericApiException() { }

        public GenericApiException(string message) : base(message) { }

        public int Code { get; set; } = 500;
        public List<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(Message);
        }
    }
}

