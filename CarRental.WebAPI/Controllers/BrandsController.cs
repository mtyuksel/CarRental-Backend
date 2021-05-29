using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : GenericBaseController<Brand, IBrandService>
    {
        public BrandsController(IBrandService brandService) : base(brandService)
        {

        }
    }
}
