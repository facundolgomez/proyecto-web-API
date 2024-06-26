using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Application.Models;

namespace Application.Services
{
    public class ReservaService : IService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto>
    {
        private readonly GenericService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto> _genericService;
        private readonly IRepository<Reserva> _reservaRepository;
        private readonly IRepository<Mascota> _mascotaRepository;
        private readonly IRepository<Guarderia> _guarderiaRepository;

        public ReservaService(
            IRepository<Reserva> reservaRepository,
            IRepository<Mascota> mascotaRepository,
            IRepository<Guarderia> guarderiaRepository,
            IMapper mapper)
        {
            _genericService = new GenericService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto>(reservaRepository, mapper);
            _reservaRepository = reservaRepository;
            _mascotaRepository = mascotaRepository;
            _guarderiaRepository = guarderiaRepository;
        }

        public ReservaDto Create(ReservaCreateRequest reservaCreateRequest)
        {
            // Verificar si la Guarderia existe
            var guarderia = _guarderiaRepository.GetById(reservaCreateRequest.GuarderiaId);
            if (guarderia == null)
            {
                throw new NotFoundException($"No se encontró la Guarderia con Id {reservaCreateRequest.GuarderiaId}");
            }

            // Verificar si la Mascota existe
            var mascota = _mascotaRepository.GetById(reservaCreateRequest.MascotaId);
            if (mascota == null)
            {
                throw new NotFoundException($"No se encontró la Mascota con Id {reservaCreateRequest.MascotaId}");
            }

            // Si ambas existen, proceder a crear la reserva
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

            // Aquí puedes implementar la lógica para notificar el cambio de estado de la reserva
        }
    }
}
