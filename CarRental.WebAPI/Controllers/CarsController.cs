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
    public class CarsController : GenericBaseController<Car, ICarService> 
    {        
        public CarsController(ICarService carService) : base(carService)
        {
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            return base.GetResponseByResultSuccess(base._tService.GetCarDetails());
        }    
    }
}
