using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models;
using Domain.Exceptions;
using Domain.Entities;
using Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "SysAdmin")]
    public class GuarderiaController : ControllerBase 
    {
        private readonly IGuarderiaService _guarderiaService;

        public GuarderiaController(IGuarderiaService guarderiaService)
        {
            _guarderiaService = guarderiaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] GuarderiaCreateRequest guarderiaCreateRequest)
        {
            var newObj = _guarderiaService.Create(guarderiaCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] GuarderiaUpdateRequest guarderiaUpdateRequest)
        {

            try
            {
                _guarderiaService.Update(id, guarderiaUpdateRequest);
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
                _guarderiaService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("[action]")]
        public ActionResult<List<GuarderiaDto>> GetAll()
        {
            return _guarderiaService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<Guarderia>> GetAllFullData()
        {
            return _guarderiaService.GetAllFullData();
        }



        [HttpGet("[action]/{id}")]
        public ActionResult<GuarderiaDto> GetById([FromRoute] int id)
        {
            try
            {
                return _guarderiaService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
    }

}