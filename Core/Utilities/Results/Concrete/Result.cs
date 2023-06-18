using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool _isSuccess, string _message) : this(_isSuccess)
        {
            Message = _message;
        }
        public Result(bool _isSuccess)
        {
            isSuccess = _isSuccess;

        }
        public bool isSuccess { get; }

        public string Message { get; }
    }
}
