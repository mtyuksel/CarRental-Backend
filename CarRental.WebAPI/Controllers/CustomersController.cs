using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : GenericBaseController<Customer, ICustomerService>
    {
        public CustomersController(ICustomerService customerService) : base(customerService)
        {

        }
    }
}
