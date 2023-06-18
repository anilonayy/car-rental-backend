using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IBrandService _brandService;

        public BrandsController(IBrandService BrandService)
        {
            _brandService = BrandService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand Brand)
        {
            var result = _brandService.Create(Brand);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Brand Brand)
        {
            var result = _brandService.Update(Brand);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _brandService.Delete(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
