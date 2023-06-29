using System.Text.Json.Serialization;

namespace Core.Utilities.Results
{
    public class CustomResult<T> : ICustomResult<T>
    {
        public CustomResult(int statusCode, bool success)
        {
            StatusCode = statusCode;
            Success = success; 
        }

        public CustomResult(int statusCode,bool success, T data): this(statusCode, success)
        {
            Data = data;
        }

        public T Data { get; }

        public bool Success { get; }

        public List<string> Errors { get; set; } = new List<string>();

        [JsonIgnore]
        public int StatusCode { get; }
    }
}
