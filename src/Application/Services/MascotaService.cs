using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services
{
    public class MascotaService : IService<Mascota, MascotaCreateRequest, MascotaUpdateRequest, MascotaDto>
    {
        private readonly GenericService<Mascota, MascotaCreateRequest, MascotaUpdateRequest, MascotaDto> _genericService;

        public MascotaService(IRepository<Mascota> repository, IMapper mapper)
        {
            _genericService = new GenericService<Mascota, MascotaCreateRequest, MascotaUpdateRequest, MascotaDto>(repository, mapper);
        }

        public MascotaDto Create(MascotaCreateRequest mascotaCreateRequest)
        {
            return _genericService.Create(mascotaCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<MascotaDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Mascota> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public MascotaDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, MascotaUpdateRequest mascotaUpdateRequest)
        {
            _genericService.Update(id, mascotaUpdateRequest);
        }
    }
}
