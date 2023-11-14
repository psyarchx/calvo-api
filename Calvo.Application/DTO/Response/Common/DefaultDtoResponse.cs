using System.Net;
using System.Text.Json.Serialization;

namespace Calvo.Application.DTO.Response.Common
{
    public class DefaultDtoResponse<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public int StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<string> Errors { get; set; }

        public DefaultDtoResponse(HttpStatusCode statusCode, T data = default)
        {
            StatusCode = (int)statusCode;
            Success = StatusCode >= 200 && StatusCode <= 299;
            Result = data;
        }

        public DefaultDtoResponse<T> AddErrorMessage(string message)
        {
            Errors ??= new List<string>();
            Errors.Add(message);
            return this;
        }
    }
}
