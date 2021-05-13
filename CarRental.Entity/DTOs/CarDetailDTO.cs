using CarRental.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entity.DTOs
{
    public class CarDetailDTO : IDTO
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
