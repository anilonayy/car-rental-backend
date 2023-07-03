using AutoMapper;
using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.PaymentDTOs;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        private readonly IMapper _mapper;

        public PaymentManager(IPaymentDal paymentDal, IMapper mapper)
        {
            _paymentDal = paymentDal;
            _mapper = mapper;
        }

        public IResult<Payment> Add(PaymentCreateDto payment)
        {
            var mapped = _mapper.Map<Payment>(payment);
            _paymentDal.Create(mapped);

            return new SuccessResult<Payment>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage,mapped);
        }
    }
}
