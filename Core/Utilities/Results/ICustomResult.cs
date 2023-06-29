using System.Text.Json.Serialization;

namespace Core.Utilities.Results
{
    public interface ICustomResult<T>
    {
        public T Data { get;}
        public bool Success { get; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; }


    }
}
