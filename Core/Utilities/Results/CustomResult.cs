using System.Text.Json.Serialization;

namespace Core.Utilities.Results
{
    public class CustomResult<T> : ICustomResult<T>
    {
        public CustomResult(int statusCode, bool issuccess)
        {
            StatusCode = statusCode;
            isSuccess = issuccess; 
        }

        public CustomResult(int statusCode,bool issuccess,T data): this(statusCode, issuccess)
        {
            Data = data;
        }

        public T Data { get; }

        public bool isSuccess { get; }

        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; }
    }
}
