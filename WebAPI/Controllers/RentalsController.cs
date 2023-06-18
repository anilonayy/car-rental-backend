using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        readonly IRentalService _rentalService;

        public RentalsController(IRentalService RentalService)
        {
            _rentalService = RentalService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Rental Rental)
        {
            var result = _rentalService.Create(Rental);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Rental Rental)
        {
            var result = _rentalService.Update(Rental);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _rentalService.Delete(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
