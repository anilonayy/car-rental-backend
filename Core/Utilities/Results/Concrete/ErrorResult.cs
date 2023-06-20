namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(int statusCode, string _message) : base(statusCode,false, _message)
        {
        }
        public ErrorResult(int statusCode) : base(statusCode,false)
        {
        }
    }
}
