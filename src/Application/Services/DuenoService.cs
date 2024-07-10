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
        private readonly IRepository<Cliente> _clienteRepository;   
        private readonly IRepository<Dueno> _duenoRepository;
        private readonly IRepository<Reserva> _reservaRepository;
        private readonly IRepository<Guarderia> _guarderiaRepository;
        private readonly INotificacionRepository _notificacionRepository;
        private readonly IMapper _mapper;

        public DuenoService(
            IRepository<Cliente> clienteRepository,
            IRepository<Dueno> duenoRepository,
            IRepository<Reserva> reservaRepository,
            IRepository<Guarderia> guarderiaRepository,
            INotificacionRepository notificacionRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _duenoRepository = duenoRepository;
            _reservaRepository = reservaRepository;
            _guarderiaRepository = guarderiaRepository;
            _notificacionRepository = notificacionRepository;
            _mapper = mapper;
        }

        public DuenoDto Create(DuenoCreateRequest duenoCreateRequest)
        {
            var dueno = _mapper.Map<Dueno>(duenoCreateRequest);
            _duenoRepository.Add(dueno);
            return _mapper.Map<DuenoDto>(dueno);
        }

        public void Delete(int id)
        {
            var dueno = _duenoRepository.GetById(id);
            if (dueno == null)
            {
                throw new NotFoundException($"No se encontró el dueño con el id {id}");
            }
            _duenoRepository.Delete(dueno);
        }

        public List<DuenoDto> GetAll()
        {
            var duenos = _duenoRepository.GetAll();
            return _mapper.Map<List<DuenoDto>>(duenos);
        }

        public List<Dueno> GetAllFullData()
        {
            return _duenoRepository.GetAll();
        }

        public DuenoDto GetById(int id)
        {
            var dueno = _duenoRepository.GetById(id);
            if (dueno == null)
            {
                throw new NotFoundException($"No se encontró el dueño con el id {id}");
            }
            return _mapper.Map<DuenoDto>(dueno);
        }

        public void Update(int id, DuenoUpdateRequest duenoUpdateRequest)
        {
            var dueno = _duenoRepository.GetById(id);
            if (dueno == null)
            {
                throw new NotFoundException($"No se encontró el dueño con el id {id}");
            }
            _mapper.Map(duenoUpdateRequest, dueno);
            _duenoRepository.Update(dueno);
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

        public List<ReservaDto> ListarReservasPendientes(int guarderiaId)
        {
            var guarderia = _guarderiaRepository.GetById(guarderiaId);
            if (guarderia == null)
            {
                throw new NotFoundException($"No se encontró la guardería con el id {guarderiaId}");
            }

            var reservasPendientes = guarderia.Reservas
                .Where(r => r.Estado == EstadoReserva.Pendiente)
                .ToList();
            return ReservaDto.CreateList(reservasPendientes);
        }

        public GuarderiaDto CrearGuarderia(GuarderiaCreateRequest guarderiaCreateRequest)
        {
            var nuevaGuarderia = _mapper.Map<Guarderia>(guarderiaCreateRequest);
            _guarderiaRepository.Add(nuevaGuarderia);
            return _mapper.Map<GuarderiaDto>(nuevaGuarderia);
        }

        public void EnviarMensajeAlCliente(int remitenteId, int clienteId, string mensaje)
        {
            var cliente = _clienteRepository.GetById(clienteId);

            if (cliente == null)
                throw new NotFoundException($"No se encontró el cliente con el id {clienteId}");

            var remitente = _duenoRepository.GetById(remitenteId);
            if (remitente == null)
                throw new NotFoundException($"No se encontró el remitente con el id {remitenteId}");

            var notificacion = new Notificacion
            {
                RemitenteId = remitenteId,
                RemitenteRole = remitente.UserRole,
                DestinatarioId = clienteId,
                DestinatarioRole = cliente.UserRole,
                Mensaje = mensaje,
                FechaCreado = DateTime.Now,
                EstadoMensaje = EstadoMensaje.Pendiente
            };

            _notificacionRepository.Add(notificacion);
        }

        public List<NotificacionDto> VerNotificaciones(int duenoId)
        {
            var notificaciones = _notificacionRepository.GetByUsuarioId(duenoId);
            foreach (var n in notificaciones)
            {
                n.EstadoMensaje = EstadoMensaje.Leido;
            }
            _notificacionRepository.SaveChanges();
            return _mapper.Map<List<NotificacionDto>>(notificaciones);
        }
    }
}
