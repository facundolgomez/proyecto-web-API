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

        [HttpPost]
        [Authorize(Policy = "SysAdmin")]
        public IActionResult Create([FromBody] DuenoCreateRequest dueñoCreateRequest)
        {
            var newObj = _duenoService.Create(dueñoCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }
        
       
        [HttpPut("{id}")]
        [Authorize(Policy = "SysAdmin")]
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
        [Authorize(Policy = "SysAdmin")]
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

        
        [HttpGet("[action]")]
        [Authorize(Policy = "SysAdmin")]
        public ActionResult<List<DuenoDto>> GetAll()
        {
            return _duenoService.GetAll();
        }


        
        [HttpGet("[action]")]
        [Authorize(Policy = "SysAdmin")]
        public ActionResult<List<Dueno>> GetAllFullData()
        {
            return _duenoService.GetAllFullData();
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "SysAdmin")]
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

        [HttpPut("{reservaId}/aceptar-reserva")]
        [Authorize(Policy = "Dueno")]
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


        [HttpPut("{reservaId}/cancelar-reserva")]
        [Authorize(Policy = "Dueno")]
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

        
        

        
        [HttpPost("crear-guarderia")]
        [Authorize(Policy = "Dueno")]
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


        [HttpGet("{guarderiaId}/lista-reservas-pendientes")]
        [Authorize(Policy = "Dueno")]
        public ActionResult<List<ReservaDto>> ListarReservasPendientes(int guarderiaId)
        {
            try
            {
                return _duenoService.ListarReservasPendientes(guarderiaId);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        //endpoints recien agregados
        
        [HttpPost("{remitenteId}/{clienteId}/enviar-mensaje-al-cliente")]
        [Authorize(Policy = "Dueno")]
        public IActionResult EnviarMensajeAlCliente([FromRoute] int remitenteId, [FromRoute] int clienteId, [FromBody] string mensaje)
        {
            try
            {
                _duenoService.EnviarMensajeAlCliente(remitenteId, clienteId, mensaje);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{duenoId}/ver-notificaciones")]
        [Authorize(Policy = "Dueno")]
        public ActionResult<List<NotificacionDto>> VerNotificaciones([FromRoute] int duenoId)
        {
            try
            {
                var notificaciones = _duenoService.VerNotificaciones(duenoId);
                return Ok(notificaciones);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
