using FluentValidation.Results;

namespace Core.Extensions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> errors { get; set; }
    }
}