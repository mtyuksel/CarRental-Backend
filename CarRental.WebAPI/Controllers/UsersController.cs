using CarRental.Business.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericBaseController<User, IUserService>
    {
        public UsersController(IUserService userService) : base(userService)
        {
                
        }
    }
}
