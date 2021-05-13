﻿using CarRental.Business.Abstract;
using CarRental.Core.Utilities.Results;
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
    public class RentalsController : GenericBaseController<Rental, IRentalService>
    {
        public RentalsController(IRentalService rentalService) : base(rentalService)
        {
        }
    }
}
