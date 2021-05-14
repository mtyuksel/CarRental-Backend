using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : GenericBaseController<Rental, IRentalService>
    {
        public RentalsController(IRentalService rentalService) : base(rentalService)
        {
        }
    }
}
