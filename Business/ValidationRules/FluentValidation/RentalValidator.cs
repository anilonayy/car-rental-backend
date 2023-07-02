using Entities.DTOs.RentalDTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<RentalCreateDto>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate.Date).LessThan(r => r.PlannedReturnDate.Date);
        }
    }
}
