namespace Core.Utilities.Results
{
    public class ErrorResult<T> : CustomResult<T>
    {
        public ErrorResult(int statusCode, string error) : base(statusCode, false)
        {
            Errors.Add(error);
        }
        public ErrorResult(int statusCode, List<string> errors) : base(statusCode, false)
        {
            Errors.AddRange(errors);
        }
    }
}
