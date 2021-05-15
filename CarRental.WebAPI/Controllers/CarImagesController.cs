using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment)
        {
            this._carImageService = carImageService;
            _environment = environment;
            _uploadPath = _environment.WebRootPath + "\\Images\\Uploads\\";
        }

        public class FileUpload
        {
            public Guid ID { get { return Guid.NewGuid(); } }
            public IFormFile Files { get; set; }
            public string CarImage { get; set; }
        }

        [HttpPost("add")]
        public IResult Add([FromForm] FileUpload fileUpload)
        {
            var fileCheck = CheckIfFileUploaded(fileUpload.Files);

            if (fileCheck.Success)
            {
                var filename = Guid.NewGuid().ToString() + ".png";

                CarImage carImage = JsonConvert.DeserializeObject<CarImage>(fileUpload.CarImage);

                carImage.ImagePath = filename;
                carImage.Date = DateTime.Now;

                var result = _carImageService.Add(carImage);

                if (!result.Success)
                {
                    return result;
                }

                return SaveImage(fileUpload, filename);
            }

            return fileCheck;
        }

        [HttpPost("delete")]
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);

            if (!result.Success)
            {
                return result;
            }

            return DeleteImage(carImage.ImagePath);
        }

        [HttpPost("update")]
        public IResult Update([FromForm] FileUpload fileUpload)
        {
            var fileCheck = CheckIfFileUploaded(fileUpload.Files);

            if (fileCheck.Success)
            {
                CarImage carImage = JsonConvert.DeserializeObject<CarImage>(fileUpload.CarImage);
                carImage.Date = DateTime.Now;

                var result = _carImageService.GetByImagePath(carImage.ImagePath);

                if (!result.Success)
                {
                    return result;
                }

                return UpdateImage(fileUpload, carImage.ImagePath);
            }

            return fileCheck;
        }

        private IResult SaveImage(FileUpload fileUpload, string fileName)
        {

            if (Directory.Exists(_uploadPath))
            {
                using (FileStream fileStream = System.IO.File.Create(_uploadPath + fileName))
                {
                    fileUpload.Files.CopyTo(fileStream);
                    fileStream.Flush();

                    return new SuccessResult("File Added.");
                }
            }

            return new ErrorResult("There is an error occured while image adding!");
        }

        private IResult UpdateImage(FileUpload fileUpload, string fileName)
        {
            if (Directory.Exists(_uploadPath))
            {
                using (FileStream fileStream = System.IO.File.OpenWrite(_uploadPath + fileName))
                {
                    fileUpload.Files.CopyTo(fileStream);
                    fileStream.Flush();

                    return new SuccessResult("File Updated.");
                }
            }

            return new ErrorResult("There is an error occured while image updating!");
        }

        private IResult DeleteImage(string imagePath)
        {
            System.IO.File.Delete(_uploadPath + imagePath);

            return new SuccessResult("File Deleted.");
        }

        private IResult CheckIfFileUploaded(IFormFile formFile)
        {
            if (formFile == null || formFile.Length < 1)
            {
                return new ErrorResult("Please select at least one image to upload!");
            }

            return new SuccessResult();
        }
    }
}
