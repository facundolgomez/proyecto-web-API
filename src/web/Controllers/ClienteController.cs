﻿using Application.Interfaces;
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
    
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        
        [HttpPost]
        [Authorize(Policy = "Dueno")]
        public IActionResult Create([FromBody] ClienteCreateRequest clienteCreateRequest)
        {
            var newObj = _clienteService.Create(clienteCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }

        
        [HttpPut("{id}")]
        [Authorize(Policy = "Dueno")]
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
        [Authorize(Policy = "Dueno")]
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
        [Authorize(Policy = "Dueno")]
        public ActionResult<List<ClienteDto>> GetAll()
        {
            return _clienteService.GetAll();
        }



        [HttpGet("[action]")]
        [Authorize(Policy = "Dueno")]
        public ActionResult<List<Cliente>> GetAllFullData()
        {
            return _clienteService.GetAllFullData();
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "Dueno")]
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
        [Authorize(Policy = "Dueno")]
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


        [HttpPost("{mascotaId}/crear-reserva")]
        [Authorize(Policy = "ClienteODueno")]
        public IActionResult CrearReserva([FromRoute] int mascotaId, [FromBody] ReservaCreateRequest reservaCreateRequest)
        {
            try
            {
                var newObj = _clienteService.CrearReserva(mascotaId, reservaCreateRequest);
                return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{reservaId}/cancelar-reserva")]
        [Authorize(Policy = "ClienteODueno")]
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
        [Authorize(Policy = "Cliente")]
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
        [Authorize(Policy = "Cliente")]
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

