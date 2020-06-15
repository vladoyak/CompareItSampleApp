using Microsoft.AspNetCore.Mvc;
using SourceSystem.Models;
using SourceSystem.Rabbit;
using SourceSystem.Services;
using System;
using System.CodeDom.Compiler;
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
        private readonly IInsuranceAddingSender _insuranceAddingSender;

        public InsuranceController(IInsuranceService insuranceService, IInsuranceAddingSender insuranceAddingSender)
        {
            _insuranceService = insuranceService;
            _insuranceAddingSender = insuranceAddingSender;
            Generate();
        }

        public void Generate()
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
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_insuranceService.Get());
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

        [HttpPost]
        public IActionResult Insert([FromBody]Insurance insurance)
        {
            int addedId = _insuranceService.Add(insurance);
            if (addedId != default)
            {
                _insuranceAddingSender.SendInsurance(insurance);
                return CreatedAtAction("FindOne", _insuranceService.Get(addedId));
            }
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
