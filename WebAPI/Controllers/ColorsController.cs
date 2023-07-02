using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class ColorsController : CustomControllerBase
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
            return CreateResponse(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            return CreateResponse(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color Color)
        {
            var result = _colorService.Create(Color);
            return CreateResponse(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Color Color)
        {
            var result = _colorService.Update(Color);
            return CreateResponse(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _colorService.Delete(id);
            return CreateResponse(result);
        }
    }
}
