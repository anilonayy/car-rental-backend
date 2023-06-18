namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string _message) : base(false, _message)
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}
