using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        IBrandService _brandservice;
        public BrandsController(IBrandService brandservice)
        {
            _brandservice = brandservice;
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandservice.Add(brand);
            if(result.Success)
                return Ok(result);
            else return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandservice.Delete(brand);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandservice.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandservice.GetById(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandservice.Update(brand);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }
    }
}
