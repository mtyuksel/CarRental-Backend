using CarRental.Core.Entity.Abstract;

namespace CarRental.Entity.Concrete
{
    public class Brand : IEntity
    { 
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
