using CarRental.Core.Entity.Abstract;

namespace CarRental.Entity.DTOs
{
    public class UserForLoginDTO : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}