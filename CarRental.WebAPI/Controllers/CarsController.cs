using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase 
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            this._carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResultSuccess(_carService.GetAll());
        }
        
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            return GetResponseByResultSuccess(_carService.GetCarDetails());
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            return GetResponseByResultSuccess(_carService.GetByID(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            return GetResponseByResultSuccess(_carService.Add(car));
        }
        
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            return GetResponseByResultSuccess(_carService.Update(car));
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            return GetResponseByResultSuccess(_carService.Delete(car));
        }

        private IActionResult GetResponseByResultSuccess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
