using CarRental.Core.Entity.Abstract;

namespace CarRental.Entity.Concrete
{
    public class City : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
