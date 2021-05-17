using CarRental.Business.Abstract;
using CarRental.Core.Entity.Abstract;
using CarRental.Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.WebAPI.Controllers
{
    //This class is base for CRUD operations.
    //Thanks to this class, CRUD operations can be performed for each controller without code repetition.
    [ApiController]
    public class GenericBaseController<TEntity, TService> : ControllerBase
        where TService : IServiceBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected TService _tService;

        public GenericBaseController(TService tService) => this._tService = tService;

        [HttpGet("getall")]
        public virtual async Task<IActionResult> GetAll() => GetResponseByResultSuccess(await _tService.GetAll());

        [HttpGet("getbyid")]
        public virtual async Task<IActionResult> GetByID(int id) => GetResponseByResultSuccess(await _tService.GetByID(id));

        [HttpPost("add")]
        public virtual async Task<IActionResult> Add(TEntity entity) => GetResponseByResultSuccess(await _tService.Add(entity));

        [HttpPost("update")]
        public virtual async Task<IActionResult> Update(TEntity entity) => GetResponseByResultSuccess(await _tService.Update(entity));

        [HttpPost("delete")]
        public virtual async Task<IActionResult> Delete(TEntity entity) => GetResponseByResultSuccess(await _tService.Delete(entity));

        protected IActionResult GetResponseByResultSuccess(IResult result) => result.Success ? Ok(result) : BadRequest(result);
    }
}
