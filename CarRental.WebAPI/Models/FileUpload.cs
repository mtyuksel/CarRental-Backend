using Microsoft.AspNetCore.Http;
using System;

namespace CarRental.WebAPI.Models
{
    public class FileUpload
    {
        public Guid ID { get { return Guid.NewGuid(); } }
        public IFormFile Files { get; set; }
        public string CarImage { get; set; }
    }
}
