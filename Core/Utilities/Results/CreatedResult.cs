namespace Core.Utilities.Results
{
    public class CreatedResult<T> : CustomResult<T>
    {
        public CreatedResult(string title , string message,T data) : base(201,true,title, message,data)
        {
            if(message==null)
            {
                this.message = Messages.OperationMessages.SuccessMessage;
            }
            
        }

        public CreatedResult(string title , string message) : base(201, true,title, message)
        {
            if (message == null)
            {
                this.message = Messages.OperationMessages.SuccessMessage;
            }
        }
    }
}
