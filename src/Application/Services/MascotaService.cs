using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Domain.Exceptions;

namespace Application.Services
{

    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository _mascotaRepositorySpecific;
        private readonly IRepository<Mascota> _mascotaRepository;
        private readonly IMapper _mapper;

        public MascotaService(IRepository<Mascota> mascotaRepository, IMascotaRepository mascotaRepositorySpecific, IMapper mapper)
        {
            _mascotaRepositorySpecific = mascotaRepositorySpecific;
            _mascotaRepository = mascotaRepository;
            _mapper = mapper;
        }

        public MascotaDto Create(MascotaCreateRequest mascotaCreateRequest)
        {
            var mascota = _mapper.Map<Mascota>(mascotaCreateRequest);
            _mascotaRepository.Add(mascota);
            return _mapper.Map<MascotaDto>(mascota);
        }

        public void Delete(int id)
        {
            var mascota = _mascotaRepository.GetById(id);
            if (mascota == null)
            {
                throw new NotFoundException($"No se encontró la mascota con el ID {id}");
            }
            _mascotaRepository.Delete(mascota);
        }

        public List<MascotaDto> GetAll()
        {
            var mascotas = _mascotaRepository.GetAll();
            return _mapper.Map<List<MascotaDto>>(mascotas);
        }

        public List<MascotaDto> GetPetsWithReservations()
        {
            var mascotas = _mascotaRepositorySpecific.GetPetsWithReservations().ToList();
            return _mapper.Map<List<MascotaDto>>(mascotas);
        }

        public MascotaDto GetById(int id)
        {
            var mascota = _mascotaRepository.GetById(id);
            return _mapper.Map<MascotaDto>(mascota);
        }

        public void Update(int id, MascotaUpdateRequest mascotaUpdateRequest)
        {
            var mascota = _mascotaRepository.GetById(id);
            if (mascota == null)
            {
                throw new NotFoundException($"No se encontró la mascota con el ID {id}");
            }

            _mapper.Map(mascotaUpdateRequest, mascota);


            _mascotaRepository.Update(mascota);
        }
    }
}
