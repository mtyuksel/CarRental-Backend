using CarRental.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entity.Concrete
{
    public class Customer : IEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserID { get; set; }
        public string CompanyName { get; set; }
    }
}
