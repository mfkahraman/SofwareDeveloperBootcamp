using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPut("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if(result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car) 
        { 
            var result = _carService.Delete(car);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails() 
        { 
            var result = _carService.GetCarDetails();
            if(result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }
    }
}
