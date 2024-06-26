using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Cliente")]
    public class ReservaController : ControllerBase
    {
        private readonly IService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto> _reservaService;

        public ReservaController(IService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto> reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReservaCreateRequest reservaCreateRequest)
        {
            var newObj = _reservaService.Create(reservaCreateRequest);

            return Ok(newObj);
        }
    }
}
