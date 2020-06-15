using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontendAPI.Models;
using FrontendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendAPI.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            //var cust = new Customer
            //{
            //    Name = "Vladimir Zak",
            //    Email = "vladimir.zak@sampleapp.com",
            //};

            //Insert(cust);
            //Delete(2);

            return _customerService.FindAll();
        }

        public IActionResult Insert(Customer customer)
        {
            var id = _customerService.Insert(customer);
            if (id != default)
                return CreatedAtAction("FindOne", _customerService.FindOne(id));
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<WeatherForecast> Delete(int id)
        {
            var result = _customerService.Delete(id);
            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
