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
        private readonly IDuenoService _dueñoService;
        public DuenoController(IDuenoService subjectService)
        {
            _dueñoService = subjectService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] DuenoCreateRequest dueñoCreateRequest)
        {
            var newObj = _dueñoService.Create(dueñoCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DuenoUpdateRequest subjectUpdateRequest)
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
        public ActionResult<List<DuenoDto>> GetAll()
        {
            return _dueñoService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<Dueno>> GetAllFullData()
        {
            return _dueñoService.GetAllFullData();
        }



        [HttpGet("{id}")]
        public ActionResult<DuenoDto> GetById([FromRoute] int id)
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
