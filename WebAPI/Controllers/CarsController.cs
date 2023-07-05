using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class CarsController : CustomControllerBase
    {
        readonly ICarService _carService;

        public CarsController(ICarService CarService)
        {
            _carService = CarService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetWithDetails();
            return CreateResponse(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            return CreateResponse(result);
        }
        [HttpGet("GetByColor")]
        public IActionResult GetByColor(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);

            return CreateResponse(result);
        }

        [HttpGet("GetByColorAndBrand")]
        public IActionResult GetByColorAndBrand(int colorId, int brandId)
        {
            var result = _carService.GetByColorAndBrand(colorId, brandId);

            return CreateResponse(result);
        }

        [HttpGet("GetByBrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);

            return CreateResponse(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Car Car)
        {
            var result = _carService.Create(Car);
            return CreateResponse(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Car Car)
        {
            var result = _carService.Update(Car);
            return CreateResponse(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(id);
            return CreateResponse(result);
        }
    }
}
