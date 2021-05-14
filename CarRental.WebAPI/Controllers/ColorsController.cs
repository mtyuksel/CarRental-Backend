using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : GenericBaseController<Color, IColorService>
    {
        public ColorsController(IColorService colorService) : base (colorService)
        {

        }
    }
}
