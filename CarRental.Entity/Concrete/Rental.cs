using CarRental.Core.Entity.Abstract;
using System;

namespace CarRental.Entity.Concrete
{
    public class Rental : IEntity
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
