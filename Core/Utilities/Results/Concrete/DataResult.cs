using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(int statusCode,T _data, bool _isSuccess, string _message) : base(statusCode,_isSuccess, _message)
        {
            Data = _data;
        }
        public DataResult(int statusCode, T _data, bool _isSuccess) : base(statusCode,_isSuccess)
        {
            Data = _data;
        }
    }
}
