namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public bool isSuccess { get; }
        public string Message { get; }
    }
}
