using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class BrandsController : CustomControllerBase
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
            return CreateResponse(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            return CreateResponse(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand Brand)
        {
            var result = _brandService.Create(Brand);

            return CreateResponse(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Brand Brand)
        {
            var result = _brandService.Update(Brand);
            return CreateResponse(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _brandService.Delete(id);
            return CreateResponse<Brand>(result);
        }
    }
}
