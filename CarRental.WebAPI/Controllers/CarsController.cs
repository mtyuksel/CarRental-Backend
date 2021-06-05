using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

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
            this._uploadPath = configuration.GetSection("DefaultOptions").GetSection("Image").GetSection("UploadPath").Value;

            string defaultImagePath = configuration.GetSection("DefaultOptions").GetSection("Image").GetSection("DefaultUploadPath").Value;
            string defaultImageName = configuration.GetSection("DefaultOptions").GetSection("Image").GetSection("DefaultName").Value;

            this._defaultImageFullPath = defaultImagePath + defaultImageName;
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}";
            return base.GetResponseByResultSuccess(base._tService.GetCarDetails(baseUrl + _uploadPath, baseUrl + _defaultImageFullPath));
        }

        [HttpGet("getbylocation")]
        public IActionResult GetByLocation(int locationID)
        {
            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}";
            return base.GetResponseByResultSuccess(base._tService.GetDetailedCarsByLocation(locationID, baseUrl + _uploadPath, baseUrl + _defaultImageFullPath));
        }

    }
}
