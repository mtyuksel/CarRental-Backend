using CarRental.Core.Entity.Abstract;
using CarRental.Entity.Concrete;
using System;
using System.Collections.Generic;

namespace CarRental.Entity.DTOs
{
    public class CarDetailDTO : IDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set;}
        public Color Color { get; set; }
        public LocationDTO Location { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public List<CarImage> Images { get; set; }
    }
}
