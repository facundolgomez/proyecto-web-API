using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models;
using Domain.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "SysAdmin")]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MascotaCreateRequest mascotaCreateRequest)
        {
            var newObj = _mascotaService.Create(mascotaCreateRequest);

            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MascotaUpdateRequest mascotaUpdateRequest)
        {

            try
            {
                _mascotaService.Update(id, mascotaUpdateRequest);
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
                _mascotaService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("[action]")]
        public ActionResult<List<MascotaDto>> GetAll()
        {
            return _mascotaService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<MascotaDto>> GetAllFullData()
        {
            return _mascotaService.GetPetsWithReservations();
        }



        [HttpGet("{id}")]
        public ActionResult<MascotaDto> GetById([FromRoute] int id)
        {
            try
            {
                return _mascotaService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}