namespace Core.Utilities.Results
{
    public class SuccessResult<T> : CustomResult<T>
    {
        public SuccessResult(string title,string message,T data) : base(200, true,title, message,data)
        {
        }
        public SuccessResult(string title ,string message) : base(200, true,title, message)
        {
        }
    }
}
