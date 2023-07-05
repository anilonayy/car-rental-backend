using Business.Abstract;
using Entities.DTOs.CarImageDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CarImagesController : CustomControllerBase
    {
        readonly ICarImageService _CarImageService;

        public CarImagesController(ICarImageService CarImageService)
        {
            _CarImageService = CarImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _CarImageService.GetAll();
            return CreateResponse(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _CarImageService.GetById(id);
            return CreateResponse(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] CarImageRangeDto dto)
        {
            var result = await _CarImageService.CreateRangeAsync(dto);
            return CreateResponse(result);
        }
       


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] CarImageUpdateDto dto)
        {
            var result = await _CarImageService.UpdateAsync(dto);
            return CreateResponse(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _CarImageService.Delete(id);
            return CreateResponse(result);
        }

        [HttpDelete("DeleteByCar")]
        public async Task<IActionResult> DeleteByCarAsync(int carId)
        {
            var result = await _CarImageService.DeleteByCarAsync(carId);
            return CreateResponse(result);

        }
        [HttpGet("GetImagesByCarId")]
        public async Task<IActionResult> GetImagesByCarId(int carId)
        {
            var result = await _CarImageService.GetImagesByCarId(carId);
            return CreateResponse(result);
        }


    }
}
