using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class RentalsController : CustomControllerBase
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

            var x = CreateResponse(result);

            return x;
        }


        [HttpGet("GetRentalsWithDetail")]
        public IActionResult GetRentalsWithDetail()
        {
            var result = _rentalService.GetRentalsWithDetail();
            return CreateResponse(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetRentalWithDetail(id);
            return CreateResponse(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(RentalCreateDto Rental)
        {
            var result = _rentalService.Create(Rental);
            return CreateResponse(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Rental Rental)
        {
            var result = _rentalService.Update(Rental);
            return CreateResponse(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _rentalService.Delete(id);
            return CreateResponse(result);
        }
    }
}
