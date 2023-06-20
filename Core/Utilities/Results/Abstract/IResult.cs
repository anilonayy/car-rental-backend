using System.Text.Json.Serialization;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public bool IsSuccess { get; }
        public List<string> Messages { get; }
        public int StatusCode { get;  }


    }
}
