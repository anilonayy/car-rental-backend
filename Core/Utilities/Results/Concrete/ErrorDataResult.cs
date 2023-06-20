namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(int statusCode,T _data) : base(statusCode,_data, false)
        {
        }

        public ErrorDataResult(int statusCode,T _data, string _message) : base(statusCode,_data, false, _message)
        {
        }
    }
}
