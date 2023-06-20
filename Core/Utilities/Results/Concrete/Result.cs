using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(int statuscode,bool isSuccess, string messages) : this(statuscode, isSuccess)
        {
            Messages.Add(messages);
        }
        public Result(int statuscode, bool _isSuccess)
        {
            IsSuccess = _isSuccess;
            StatusCode = statuscode;

        }
        public bool IsSuccess { get; }

        public List<string> Messages { get; }
        public int StatusCode { get; }

    }
}
