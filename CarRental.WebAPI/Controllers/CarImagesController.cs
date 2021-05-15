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

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment)
        {
            this._carImageService = carImageService;
            _environment = environment;
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
            var filename = Guid.NewGuid().ToString() + ".png";

            CarImage carImage = JsonConvert.DeserializeObject<CarImage>(fileUpload.CarImage);
            carImage.Date = DateTime.Now;

            var result = _carImageService.Update(carImage);

            if (!result.Success)
            {
                return result;
            }

            return SaveImage(fileUpload, filename);
        }

        private IResult SaveImage(FileUpload fileUpload, string fileName)
        {
            if (fileUpload.Files.Length > 0)
            {
                string path = _environment.WebRootPath + "\\Images\\Uploads\\";

                if (Directory.Exists(path))
                {
                    if (IsImageExists(path + fileName))
                    {
                        return UpdateImage(fileUpload, fileName, path);
                    }
                    else
                    {
                        return SaveImage(fileUpload, fileName, path);
                    }
                }
            }

            return new ErrorResult("An error occured while saving the image!");
        }

        private static IResult SaveImage(FileUpload fileUpload, string fileName, string path)
        {
            using (FileStream fileStream = System.IO.File.Create(path + fileName))
            {
                fileUpload.Files.CopyTo(fileStream);
                fileStream.Flush();

                return new SuccessResult("File Added.");
            }
        }

        private static IResult UpdateImage(FileUpload fileUpload, string fileName, string path)
        {
            using (FileStream fileStream = System.IO.File.OpenRead(path + fileName))
            {
                fileUpload.Files.CopyTo(fileStream);
                fileStream.Flush();

                return new SuccessResult("File Updated.");
            }
        }

        private IResult DeleteImage(string imagePath)
        {
            string path = _environment.WebRootPath + "\\Images\\Uploads\\";
            System.IO.File.Delete(path + imagePath);

            return new SuccessResult("File Deleted.");
        }

        private bool IsImageExists(string imagePath)
        {
            return Directory.Exists(imagePath);
        }
    }
}
