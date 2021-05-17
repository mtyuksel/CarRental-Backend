using CarRental.Entity.Concrete;

namespace CarRental.Entity.DTOs
{
    public class LocationDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}
