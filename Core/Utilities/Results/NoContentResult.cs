namespace Core.Utilities.Results
{
    public class NoContentResult<T> : CustomResult<T>
    {
        public NoContentResult() : base(204,true,"","")
        {
            
        }
    }
}
