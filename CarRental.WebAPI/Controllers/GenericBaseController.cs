using CarRental.Business.Abstract;
using CarRental.Core.Entity.Abstract;
using CarRental.Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    //This class is base for CRUD operations.
    //Thanks to this class, CRUD operations can be performed for each controller without code repetition.
    [ApiController]
    public class GenericBaseController<T, TService> : ControllerBase
        where TService : IServiceBase<T>
        where T : IEntity
    {
        protected TService _tService;

        public GenericBaseController(TService tService) => this._tService = tService;

        [HttpGet("getall")]
        public virtual IActionResult GetAll() => GetResponseByResultSuccess(_tService.GetAll());

        [HttpGet("getbyid")]
        public virtual IActionResult GetByID(int id) => GetResponseByResultSuccess(_tService.GetByID(id));

        [HttpPost("add")]
        public virtual IActionResult Add(T entity) => GetResponseByResultSuccess(_tService.Add(entity));

        [HttpPost("update")]
        public virtual IActionResult Update(T entity) => GetResponseByResultSuccess(_tService.Update(entity));

        [HttpPost("delete")]
        public virtual IActionResult Delete(T entity) => GetResponseByResultSuccess(_tService.Delete(entity));

        protected IActionResult GetResponseByResultSuccess(IResult result) => result.Success ? Ok(result) : BadRequest(result);
    }
}
