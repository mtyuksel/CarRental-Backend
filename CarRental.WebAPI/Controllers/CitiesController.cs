using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : GenericBaseController<City, ICityService>
    {
        public CitiesController(ICityService cityService) : base(cityService)
        {

        }
    }
}
