using Microsoft.AspNetCore.Mvc;
using SourceSystem.Models;
using SourceSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceSystem.Controllers
{
    [Controller]
    [Route("insurance")]
    public class InsuranceController : Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Insurance> Get()
        {
            var insurance = new Insurance
            {
                InsuranceType = InsuranceType.Car,
                CustomerEmail = "vladimir.zak@sampleapp.com",
            };
            var insurance2 = new Insurance
            {
                InsuranceType = InsuranceType.Life,
                CustomerEmail = "darina.zak@sampleapp.com",
            };

            Insert(insurance);
            Insert(insurance2);
            //Delete(2);

            return _insuranceService.Get();
        }

        [HttpGet("{id}")]        
        public IActionResult Get(int id)
        {
            var result = _insuranceService.Get(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        public IActionResult Insert(Insurance insurance)
        {
            int addedId = _insuranceService.Add(insurance);
            if (addedId != default)
                return CreatedAtAction("FindOne", _insuranceService.Get(addedId));
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<Insurance> Delete(int id)
        {
            _insuranceService.Delete(id);
            return NoContent();
        }
    }
}
