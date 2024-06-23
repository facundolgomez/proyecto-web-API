using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuenoController : ControllerBase
    {
        private readonly IDuenoService _duenoService;

        public DuenoController(IDuenoService duenoService)
        {
            _duenoService = duenoService;
        }
        
        [Authorize(Policy = "Dueno")]
        [HttpPost]
        public IActionResult Create([FromBody] DuenoCreateRequest dueñoCreateRequest)
        {
            var newObj = _duenoService.Create(dueñoCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }
        
        [Authorize(Policy = "Dueno")]
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

        [Authorize(Policy = "Dueno")]
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

        [Authorize(Policy = "Dueno")]
        [HttpGet("[action]")]
        public ActionResult<List<DuenoDto>> GetAll()
        {
            return _duenoService.GetAll();
        }


        [Authorize(Policy = "Dueno")]
        [HttpGet("[action]")]
        public ActionResult<List<Dueno>> GetAllFullData()
        {
            return _duenoService.GetAllFullData();
        }


        [Authorize(Policy = "Dueno")]
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

        [Authorize(Policy = "Dueno")]
        [HttpPut("{reservaId}/cancelar-reserva/")]
        public IActionResult CancelarReserva([FromRoute] int reservaId)
        {
            try
            {
                _duenoService.CancelarReserva(reservaId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Policy = "Dueno")]
        [HttpPut("{reservaId}/aceptar-reserva/")]
        public IActionResult AceptarReserva([FromRoute] int reservaId)
        {
            try
            {
                _duenoService.AceptarReserva(reservaId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Policy = "Dueno")]
        [HttpPost("/crear-guarderia/")]
        public IActionResult CrearGuarderia([FromBody] GuarderiaCreateRequest guarderiaCreateRequest)
        {
            try
            {
                var newObj = _duenoService.CrearGuarderia(guarderiaCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Policy = "Dueno")]
        [HttpGet("{guarderiaId}/lista-reservas-pendientes/")]
        public ActionResult<List<ReservaDto>> ListarReservasPendientes(int guarderiaId)
        {
            return _duenoService.ListarReservasPendientes(guarderiaId);
        }
    }
}
