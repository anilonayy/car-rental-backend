using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
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

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Customer Customer)
        {
            var result = _customerService.Create(Customer);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Customer Customer)
        {
            var result = _customerService.Update(Customer);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
