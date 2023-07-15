using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : Controller
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getavailablecars")]
        public IActionResult GetAvailableCars()
        {
            var result = _rentalService.GetAvailableCars();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("iscaravailable")]
        public IActionResult IsCarAvailable(int carId)
        {
            var result = _rentalService.IsCarAvailable(carId);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("rent")]
        public IActionResult Rent(int carId, int customerId)
        {
            var result = _rentalService.Rent(carId, customerId);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPatch("return")]
        public IActionResult Return(int rentalId)
        {
            var result = _rentalService.Return(rentalId);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }
    }
}
