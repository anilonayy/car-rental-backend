namespace Core.Utilities.Results
{
    public class ErrorResult<T> : CustomResult<T>
    {
        public ErrorResult(int statusCode, string _errors) : base(statusCode, false)
        {
            errors.Add(_errors);
        }
        public ErrorResult(int statusCode, List<string> _errors) : base(statusCode, false)
        {
            errors.AddRange(_errors);
        }
    }
}
