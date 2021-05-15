using CarRental.Core.Entity.Abstract;

namespace CarRental.Core.Entity.Concrete
{
    public class OperationClaim : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
