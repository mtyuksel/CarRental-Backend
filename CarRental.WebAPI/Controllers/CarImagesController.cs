using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspects.Autofac;
using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using CarRental.WebAPI.Helpers;
using CarRental.WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        public static IWebHostEnvironment _environment;
        private string _uploadPath;
        private string _defaultPath;
        private string _defaultImageName = "default-car.png";

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment)
        {
            this._carImageService = carImageService;
            _environment = environment;
            _uploadPath = _environment.WebRootPath + "\\Images\\Uploads\\";
            _defaultPath = _environment.WebRootPath + "\\Images\\System\\";
        }

        [HttpGet("getallbycarid")]
        public async Task<IActionResult> GetAllByCarID(int carID)
        {
            var result = await _carImageService.GetAllImagePathsByCarID(carID);
            string baseUrl = this.Request.Scheme + "://" + this.Request.Host + "/";

            if (result.Success)
            {
                return GetResponseByResultSuccess(ImageHelpers.Get(baseUrl, result.Data, _uploadPath));
            }

            return GetResponseByResultSuccess(ImageHelpers.Get(baseUrl, new List<string> { _defaultImageName }, _defaultPath));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] FileUpload fileUpload)
        {
            var fileCheck = CheckIfFileUploaded(fileUpload.Files);

            if (fileCheck.Success)
            {
                var filename = Guid.NewGuid().ToString() + ".png";

                CarImage carImage = JsonConvert.DeserializeObject<CarImage>(fileUpload.CarImage);

                carImage.ImagePath = filename;
                carImage.Date = DateTime.Now;

                var result = await _carImageService.Add(carImage);

                if (!result.Success)
                {
                    return GetResponseByResultSuccess(result);
                }

                return GetResponseByResultSuccess(ImageHelpers.Save(fileUpload, _uploadPath, filename));
            }

            return GetResponseByResultSuccess(fileCheck);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CarImage carImage)
        {
            var result = await _carImageService.Delete(carImage);

            if (!result.Success)
            {
                return GetResponseByResultSuccess(result);
            }

            return GetResponseByResultSuccess(ImageHelpers.Delete(_uploadPath, carImage.ImagePath));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] FileUpload fileUpload)
        {
            var fileCheck = CheckIfFileUploaded(fileUpload.Files);

            if (fileCheck.Success)
            {
                CarImage carImage = JsonConvert.DeserializeObject<CarImage>(fileUpload.CarImage);
                carImage.Date = DateTime.Now;

                var result = await _carImageService.GetByImagePath(carImage.ImagePath);

                if (!result.Success)
                {
                    return GetResponseByResultSuccess(result);
                }

                return GetResponseByResultSuccess(ImageHelpers.Update(fileUpload, _uploadPath, carImage.ImagePath));
            }

            return GetResponseByResultSuccess(fileCheck);
        }

        private IResult CheckIfFileUploaded(IFormFile formFile)
        {
            if (formFile == null || formFile.Length < 1)
            {
                return new ErrorResult("Please select at least one image to upload!");
            }

            return new SuccessResult();
        }

        private IActionResult GetResponseByResultSuccess(IResult result) => result.Success ? Ok(result) : BadRequest(result);
    }
}
