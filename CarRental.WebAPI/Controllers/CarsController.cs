using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

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
