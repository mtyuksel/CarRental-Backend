using CarRental.Business.Abstract;
using CarRental.Core.Entity.Abstract;
using CarRental.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    //This class is base for CRUD operations.
    //Thanks to this class, CRUD operations can be performed for each controller without code repetition.

    [Route("api/[controller]")]
    [ApiController]
    public class GenericBaseController<T, TService> : ControllerBase
        where TService : IServiceBase<T>
        where T : IEntity
    {
        protected TService _tService;

        public GenericBaseController(TService tService)
        {
            this._tService = tService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return GetResponseByResultSuccess(_tService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            return GetResponseByResultSuccess(_tService.GetByID(id));
        }

        [HttpPost("add")]
        public IActionResult Add(T entity)
        {
            return GetResponseByResultSuccess(_tService.Add(entity));
        }

        [HttpPost("update")]
        public IActionResult Update(T entity)
        {
            return GetResponseByResultSuccess(_tService.Update(entity));
        }

        [HttpPost("delete")]
        public IActionResult Delete(T entity)
        {
            return GetResponseByResultSuccess(_tService.Delete(entity));
        }

        protected IActionResult GetResponseByResultSuccess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
