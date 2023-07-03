using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.PaymentDTOs;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult<Payment> Add(PaymentCreateDto payment);

    }
}
