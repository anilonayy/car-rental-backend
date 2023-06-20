namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {

        public SuccessResult(int statusCode,string _message) : base(statusCode,true, _message)
        {
        }
        public SuccessResult(int statusCode) : base(statusCode,true)
        {
        }

    }
}
