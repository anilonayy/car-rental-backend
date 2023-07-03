
namespace Core.Utilities.Results
{
    public class CustomResult<T> : IResult<T>
    {
        public CustomResult(int status, bool success,string title, string message)
        {
            this.title = title;
            this.status = status;
            this.success = success;
            this.message = message;
        }
        public CustomResult(int status, bool success,string title,string message, T _data) :this(status, success,title, message)
        {
            data = _data;
        }

        public int status { get; }
        public bool success { get; }
        public string title { get; set; }
        public string message { get; set; }
        public T? data { get; set; }
    }
}
