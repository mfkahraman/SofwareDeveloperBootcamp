using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        IColorService _colorservice;
        public ColorsController(IColorService colorservice)
        {
            _colorservice = colorservice;
        }

        [HttpPost("Add")]
        public IActionResult Add(Entities.Concrete.Color color)
        {
            var result = _colorservice.Add(color);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Entities.Concrete.Color color)
        {
            var result = _colorservice.Delete(color);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorservice.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorservice.GetById(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Entities.Concrete.Color color)
        {
            var result = _colorservice.Update(color);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }
    }
}
