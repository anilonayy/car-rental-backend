namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(int statusCode,T _data) : base(statusCode,_data, true)
        {
        }

        public SuccessDataResult(int statusCode,T _data, string _message) : base(statusCode,_data, true, _message)
        {
        }
    }
}
