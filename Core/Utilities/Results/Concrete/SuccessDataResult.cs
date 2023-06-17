namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T _data) : base(_data, true)
        {
        }

        public SuccessDataResult(T _data ,string _message) : base(_data, true, _message)
        {
        }
    }
}
