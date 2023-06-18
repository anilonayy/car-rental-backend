using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        readonly IColorService _colorService;

        public ColorsController(IColorService ColorService)
        {
            _colorService = ColorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color Color)
        {
            var result = _colorService.Create(Color);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Color Color)
        {
            var result = _colorService.Update(Color);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _colorService.Delete(id);

            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
