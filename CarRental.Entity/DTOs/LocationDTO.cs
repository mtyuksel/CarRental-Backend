using CarRental.Entity.Concrete;

namespace CarRental.Entity.DTOs
{
    public class LocationDTO
    {
        public int LocationID { get; set; }
        public City City { get; set; }
    }
}
