using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : GenericBaseController<Location, ILocationService>
    {
        public LocationsController(ILocationService locationService) : base(locationService)
        {

        }
    }
}
