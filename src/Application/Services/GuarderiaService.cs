using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Domain.Exceptions;

namespace Application.Services
{
    public class GuarderiaService : IGuarderiaService
    {
        private readonly GenericService<Guarderia, GuarderiaCreateRequest, GuarderiaUpdateRequest, GuarderiaDto> _genericService;
        private readonly IRepository<Reserva> _reservaRepository;
        public GuarderiaService(IRepository<Guarderia> repository,IRepository<Reserva> reservaRepository, IMapper mapper)
        {
            _genericService = new GenericService<Guarderia, GuarderiaCreateRequest, GuarderiaUpdateRequest, GuarderiaDto>(repository, mapper);
            _reservaRepository = reservaRepository;
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

        public void AsignarReserva(int guarderiaId, int reservaId)
        {
            var guarderia = _genericService.GetById(guarderiaId);
            if (guarderia == null)
                throw new NotFoundException($"No se encontro la guarderia con el id {guarderiaId}");

            var reserva = _reservaRepository.GetById(reservaId);
            if (reserva == null)
                throw new NotFoundException($"No se encontro la reserva con el id {reservaId}");

           
            reserva.GuarderiaId = guarderiaId;
            _reservaRepository.Update(reserva);

        }
    }
}
