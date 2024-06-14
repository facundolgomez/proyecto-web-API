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
    public class MascotaController : ControllerBase
    {
        private readonly IService<Mascota, MascotaCreateRequest, MascotaUpdateRequest, MascotaDto> _mascotaService;

        public MascotaController(IService<Mascota, MascotaCreateRequest, MascotaUpdateRequest, MascotaDto> mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MascotaCreateRequest mascotaCreateRequest)
        {
            var newObj = _mascotaService.Create(mascotaCreateRequest);

            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, newObj);
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

        [HttpGet]
        public ActionResult<List<MascotaDto>> GetAll()
        {
            return _mascotaService.GetAll();
        }



        [HttpGet("[action]")]
        public ActionResult<List<Mascota>> GetAllFullData()
        {
            return _mascotaService.GetAllFullData();
        }



        [HttpGet("{id}")]
        public ActionResult<MascotaDto> Get([FromRoute] int id)
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