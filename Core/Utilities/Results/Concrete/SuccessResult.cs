namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {

        public SuccessResult(string _message) : base(true, _message)
        {
        }
        public SuccessResult() : base(true)
        {
        }

    }
}
