using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PaymentsController : CustomControllerBase
    {
        readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("Add")]
        public IActionResult Add(PaymentCreateDto data)
        {
            var result = _paymentService.Add(data);
            return CreateResponse(result);
        }

    }
}
