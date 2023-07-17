
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Songbook.Domain.Exceptions.v1.Common
{
    public class ApiErrors
    {
        public ApiErrorsDetail Error { get; set; }
        public override string ToString()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return JsonConvert
                .SerializeObject
                (
                    this,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = contractResolver
                    }
                );
        }
    }
    public class ApiErrorsDetail
    {
        public string Message { get; private set; }

        public int Code { get; private set; }

        public List<string> Errors { get; private set; }

        public ApiErrorsDetail(int code, List<string> errors, string message)
        {
            Message = message;
            Code = code;
            Errors = errors;
        }
    }
}

