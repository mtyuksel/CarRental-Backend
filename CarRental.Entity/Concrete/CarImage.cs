using CarRental.Core.Entity.Abstract;
using System;

namespace CarRental.Entity.Concrete
{
    public class CarImage : IEntity
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
