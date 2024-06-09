using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models;
using Domain.Exceptions;
using Domain.Entities;
namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueñoController : ControllerBase
    {
        private readonly IDueñoService _dueñoService;
        public DueñoController(IDueñoService subjectService)
        {
            _dueñoService = subjectService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] DueñoCreateRequest dueñoCreateRequest)
        {
            var newObj = _dueñoService.Create(dueñoCreateRequest);

            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, newObj);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DueñoUpdateRequest subjectUpdateRequest)
        {

            try
            {
                _dueñoService.Update(id, subjectUpdateRequest);
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
                _dueñoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult<List<DueñoDto>> GetAll()
        {
            return _dueñoService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<Dueño>> GetAllFullData()
        {
            return _dueñoService.GetAllFullData();
        }



        [HttpGet("{id}")]
        public ActionResult<DueñoDto> Get([FromRoute] int id)
        {
            try
            {
                return _dueñoService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
