namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T _data) : base(_data, false)
        {
        }

        public ErrorDataResult(T _data, string _message) : base(_data, false, _message)
        {
        }
    }
}
