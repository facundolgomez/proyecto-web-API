using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuenoController : ControllerBase
    {
        private readonly IService<Dueno, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto> _duenoService;

        public DuenoController(IService<Dueno, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto> duenoService)
        {
            _duenoService = duenoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] DuenoCreateRequest dueñoCreateRequest)
        {
            var newObj = _duenoService.Create(dueñoCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DuenoUpdateRequest subjectUpdateRequest)
        {

            try
            {
                _duenoService.Update(id, subjectUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _duenoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult<List<DuenoDto>> GetAll()
        {
            return _duenoService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<Dueno>> GetAllFullData()
        {
            return _duenoService.GetAllFullData();
        }



        [HttpGet("{id}")]
        public ActionResult<DuenoDto> GetById([FromRoute] int id)
        {
            try
            {
                return _duenoService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
