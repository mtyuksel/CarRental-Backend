using CarRental.Core.Entity.Abstract;

namespace CarRental.Entity.DTOs
{
    public class UserForRegisterDTO : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}