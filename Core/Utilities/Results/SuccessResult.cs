namespace Core.Utilities.Results
{
    public class SuccessResult<T> : CustomResult<T>
    {
        public SuccessResult(int statusCode,T data) : base(statusCode, true,data)
        {
        }
        public SuccessResult(int statusCode) : base(statusCode, true)
        {
        }
    }
}
