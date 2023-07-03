namespace Core.Utilities.Results
{
    public class ErrorResult<T> : CustomResult<T>
    {
        public IEnumerable<object> errors { get; set; }
        public ErrorResult(string title, string errorMessage,IEnumerable<object> _errors) : base(400,false,title,errorMessage)
        {
            errors = _errors;
        }
        public ErrorResult( string title ,string errorMessage) : base(400, false,title,errorMessage)
        {
        }

    }
}
