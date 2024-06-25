using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Domain.Exceptions;

namespace Application.Services
{ 
    public class ReservaService : IService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto>
    {
        private readonly GenericService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto> _genericService;
        private readonly IRepository<Reserva> _reservaRepository;

        public ReservaService(IRepository<Reserva> reservaRepository, IMapper mapper)
        {
            _genericService = new GenericService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto>(reservaRepository, mapper);
            _reservaRepository = reservaRepository;
        }

        public ReservaDto Create(ReservaCreateRequest reservaCreateRequest)
        {
            return _genericService.Create(reservaCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<ReservaDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Reserva> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public ReservaDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, ReservaUpdateRequest reservaUpdateRequest)
        {
            _genericService.Update(id, reservaUpdateRequest);
        }

        public void NotificarCambioEstadoReserva(int reservaId, string mensaje)
        {
            var reserva = _reservaRepository.GetById(reservaId);
            if (reserva == null)
                throw new NotFoundException($"No se encontró la reserva con el id {reservaId}");
            

        }
    }
}