namespace Core.Utilities.Results
{
    public interface ICustomResult<T>
    {
        public T data { get; }
        public bool success { get; }
        public List<string> errors { get; set; }
        public int statusCode { get; }


    }
}
