using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class CustomersController : CustomControllerBase
    {
        readonly ICustomerService _customerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _customerService = CustomerService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            return CreateResponse(result);
        }

        [HttpGet("GetCustomersWithDetail")]
        public IActionResult GetCustomersWithDetail()
        {
            var result = _customerService.GetCustomersWithDetail();
            return CreateResponse(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            return CreateResponse(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Customer Customer)
        {
            var result = _customerService.Create(Customer);
            return CreateResponse(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Customer Customer)
        {
            var result = _customerService.Update(Customer);
            return CreateResponse(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);
            return CreateResponse(result);
        }

    }
}
