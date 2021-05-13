using CarRental.Core.Entity.Abstract;

namespace CarRental.Entity.Concrete
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
