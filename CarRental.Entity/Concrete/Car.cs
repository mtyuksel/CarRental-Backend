using CarRental.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entity.Concrete
{
    public class Car : IEntity
    {
        public int ID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
