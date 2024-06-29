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
    [Authorize(Policy = "Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        
        [HttpPost]
        public IActionResult Create([FromBody] ClienteCreateRequest clienteCreateRequest)
        {
            var newObj = _clienteService.Create(clienteCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ClienteUpdateRequest clienteUpdateRequest)
        {

            try
            {
                _clienteService.Update(id, clienteUpdateRequest);
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
                _clienteService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpGet("[action]")]
        public ActionResult<List<ClienteDto>> GetAll()
        {
            return _clienteService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<Cliente>> GetAllFullData()
        {
            return _clienteService.GetAllFullData();
        }


        [HttpGet("{id}")]
        public ActionResult<ClienteDto> GetById([FromRoute] int id)
        {
            try
            {
                return _clienteService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{clienteId}/asignar-mascota/{mascotaId}")]
        public IActionResult AsignarMascota([FromRoute] int clienteId, [FromRoute] int mascotaId)
        {
            try
            {
                _clienteService.AsignarMascota(clienteId, mascotaId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("{clienteId}/crear-reserva/")]
        public IActionResult CrearReserva([FromRoute] int clienteId, [FromBody] ReservaCreateRequest reservaCreateRequest)
        {
            try
            {
                var newObj = _clienteService.CrearReserva(clienteId, reservaCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{reservaId}/cancelar-reserva/")]
        public IActionResult CancelarReserva([FromRoute] int reservaId)
        {
            try
            {
                _clienteService.CancelarReserva(reservaId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //endpoints recien agregados
        [HttpPost("{reservaId}/enviar-mensaje-al-dueno")]
        public IActionResult EnviarMensajeAlDueno([FromRoute] int reservaId, [FromBody] string mensaje)
        {
            try
            {
                _clienteService.EnviarMensajeAlDueno(reservaId, mensaje);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{clienteId}/ver-notificaciones")]
        public ActionResult<List<NotificacionDto>> VerNotificaciones([FromRoute] int clienteId)
        {
            try
            {
                var notificaciones = _clienteService.VerNotificaciones(clienteId);
                return Ok(notificaciones);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        

    }
}

