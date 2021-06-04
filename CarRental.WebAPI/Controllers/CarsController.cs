using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : GenericBaseController<Car, ICarService> 
    {
        private string _uploadPath;
        private string _defaultImageFullPath;
        

        public CarsController(ICarService carService, IConfiguration configuration) : base(carService)
        {
            this._uploadPath =  configuration.GetSection("DefaultOptions").GetSection("Image").GetSection("UploadPath").Value;

            string defaultImagePath = configuration.GetSection("DefaultOptions").GetSection("Image").GetSection("DefaultUploadPath").Value;
            string defaultImageName = configuration.GetSection("DefaultOptions").GetSection("Image").GetSection("DefaultName").Value;

            this._defaultImageFullPath = defaultImagePath + defaultImageName;
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            return base.GetResponseByResultSuccess(base._tService.GetCarDetails(_uploadPath, _defaultImageFullPath));
        }

        [HttpGet("getbylocation")]
        public IActionResult GetByLocation(int locationID)
        {
            return base.GetResponseByResultSuccess(base._tService.GetDetailedCarsByLocation(locationID, _uploadPath, _defaultImageFullPath));
        }

    }
} 
