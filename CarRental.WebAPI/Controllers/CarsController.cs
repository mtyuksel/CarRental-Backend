using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
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
        public async Task<IActionResult> GetCarDetails()
        {
            Thread.Sleep(50000);
            return base.GetResponseByResultSuccess(await base._tService.GetCarDetails());
        }
    }
} 
