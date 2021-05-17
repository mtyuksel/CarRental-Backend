using CarRental.Core.Utilities.Results;
using CarRental.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Helpers
{
    public static class ImageHelpers
    {
        public static IResult Get(string baseUrl, List<string> imagePaths, string filePath)
        {
            List<string> imageURLs = new List<string>();
            filePath = filePath.Substring(filePath.IndexOf("Images\\")).Replace("\\", @"/");

            foreach (var imagePath in imagePaths)
            {
                string path = baseUrl + filePath + imagePath;
                imageURLs.Add(path);
            }

            return imageURLs.Count > 0 ? new SuccessDataResult<List<string>>(imageURLs) : new ErrorDataResult<List<string>>("Files cannot found!");
        }

        public static IResult Save(FileUpload fileUpload, string path, string fileName)
        {
            if (Directory.Exists(path))
            {
                using (FileStream fileStream = System.IO.File.Create(path + fileName))
                {
                    fileUpload.Files.CopyTo(fileStream);
                    fileStream.Flush();

                    return new SuccessResult("File Added.");
                }
            }

            return new ErrorResult("There is an error occured while image adding!");
        }

        public static IResult Delete(string path, string imagePath)
        {
            System.IO.File.Delete(path + imagePath);

            return new SuccessResult("File Deleted.");
        }

        public static IResult Update(FileUpload fileUpload, string path, string fileName)
        {
            if (Directory.Exists(path))
            {
                using (FileStream fileStream = System.IO.File.OpenWrite(path + fileName))
                {
                    fileUpload.Files.CopyTo(fileStream);
                    fileStream.Flush();

                    return new SuccessResult("File Updated.");
                }
            }

            return new ErrorResult("There is an error occured while image updating!");
        }
    }
}
