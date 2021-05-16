using CarRental.Core.Entity.Abstract;

namespace CarRental.Entity.Concrete
{
    public class Location : IEntity
    {
        public int ID { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
    }
}
