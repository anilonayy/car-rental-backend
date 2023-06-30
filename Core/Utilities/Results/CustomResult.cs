using System.Text.Json.Serialization;

namespace Core.Utilities.Results
{
    public class CustomResult<T> : ICustomResult<T>
    {
        public CustomResult(int _statusCode, bool _success)
        {
            statusCode = _statusCode;
            success = _success; 
        }

        public CustomResult(int _statusCode,bool _success, T _data): this(_statusCode, _success)
        {
            data = _data;
        }

        public T data { get; }

        public bool success { get; }

        public List<string> errors { get; set; } = new List<string>();

        [JsonIgnore]
        public int statusCode { get; }
    }
}
