using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services
{
    public class GuarderiaService : IService<Guarderia, GuarderiaCreateRequest, GuarderiaUpdateRequest, GuarderiaDto>
    {
        private readonly GenericService<Guarderia, GuarderiaCreateRequest, GuarderiaUpdateRequest, GuarderiaDto> _genericService;

        public GuarderiaService(IRepository<Guarderia> repository, IMapper mapper)
        {
            _genericService = new GenericService<Guarderia, GuarderiaCreateRequest, GuarderiaUpdateRequest, GuarderiaDto>(repository, mapper);
        }

        public GuarderiaDto Create(GuarderiaCreateRequest guarderiaCreateRequest)
        {
            return _genericService.Create(guarderiaCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<GuarderiaDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Guarderia> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public GuarderiaDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, GuarderiaUpdateRequest guarderiaUpdateRequest)
        {
            _genericService.Update(id, guarderiaUpdateRequest);
        }
    }
}
