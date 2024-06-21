using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using Domain.Enums;

namespace Application.Services
{
    public class DuenoService : IDuenoService
    {
        private readonly GenericService<Dueno, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto> _genericService;
        private readonly IRepository<Reserva> _reservaRepository;
        private readonly IRepository<Guarderia> _guarderiaRepository;   
        public DuenoService(IRepository<Dueno> repository, IRepository<Reserva> reservaRepository, IRepository<Guarderia> guarderiaRepository, IMapper mapper)
        {
            _genericService = new GenericService<Dueno, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto>(repository, mapper);
            _reservaRepository = reservaRepository;
            _guarderiaRepository = guarderiaRepository;
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

        public List<Dueno> GetAllFullData()
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

        
        
        public void AceptarReserva(int reservaId)
        {
            var reserva = _reservaRepository.GetById(reservaId);
            if (reserva == null)
            {
                throw new NotFoundException($"No se encontró la reserva con el id {reservaId}");

            }
            reserva.Estado = EstadoReserva.Aprobada;
            _reservaRepository.Update(reserva);
        }

        public void CancelarReserva(int reservaId)
        {
            var reserva = _reservaRepository.GetById(reservaId);
            if (reserva == null)
            {
                throw new NotFoundException($"No se encontró la reserva con el id {reservaId}");

            }

            reserva.Estado = EstadoReserva.Rechazada;
            _reservaRepository.Update(reserva);



        }

        public List<Reserva> ListarReservasPendientes(int guarderiaId)
        {
            var guarderia =  _guarderiaRepository.GetById(guarderiaId);
            if (guarderia == null)
            {
                throw new NotFoundException($"No se encontró la guarderia con el id {guarderiaId}");

            }
            
            var reservasPendientes = guarderia.Reservas
                .Where(r => r.Estado == EstadoReserva.Pendiente)
                .ToList();
            return reservasPendientes;
        }

    }
}
