using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        readonly ICarService _carService;

        public CarsController(ICarService CarService)
        {
            _carService = CarService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Car Car)
        {
            var result = _carService.Create(Car);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Car Car)
        {
            var result = _carService.Update(Car);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
