using CarRental.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entity.Concrete
{
    public class Brand : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
