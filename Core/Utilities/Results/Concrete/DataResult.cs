using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T _data, bool _isSuccess, string _message) : base(_isSuccess, _message)
        {
            Data = _data;
        }
        public DataResult(T _data, bool _isSuccess) : base(_isSuccess)
        {
            Data = _data;
        }
    }
}
