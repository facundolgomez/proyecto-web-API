using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services
{
    public class DuenoService : IService<Guarderia, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto>
    {
        private readonly GenericService<Guarderia, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto> _genericService;

        public DuenoService(IRepository<Guarderia> repository, IMapper mapper)
        {
            _genericService = new GenericService<Guarderia, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto>(repository, mapper);
        }

        public DuenoDto Create(DuenoCreateRequest duenoCreateRequest)
        {
            return _genericService.Create(duenoCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<DuenoDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Guarderia> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public DuenoDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, DuenoUpdateRequest duenoUpdateRequest)
        {
            _genericService.Update(id, duenoUpdateRequest);
        }
    }
}
