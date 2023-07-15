using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        ICustomerService _customerservice;
        public CustomersController(ICustomerService customerservice)
        {
            _customerservice = customerservice;
        }

        [HttpPost("Add")]
        public IActionResult Add(Entities.Concrete.Customer customer)
        {
            var result = _customerservice.Add(customer);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerservice.Delete(customer);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerservice.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerservice.GetById(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerservice.Update(customer);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }
    }
}
