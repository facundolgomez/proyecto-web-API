using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IRepository<Reserva> _reservaRepository;
        private readonly IRepository<Guarderia> _guarderiaRepository;
        private readonly INotificacionRepository _notificacionRepository;
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        public ClienteService(IRepository<Cliente> clienteRepository, IMascotaRepository mascotaRepository,
            IRepository<Reserva> reservaRepository, IRepository<Guarderia> guarderiaRepository,
            INotificacionRepository notificacionRepository, INotificacionService notificacionService, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mascotaRepository = mascotaRepository;
            _reservaRepository = reservaRepository;
            _guarderiaRepository = guarderiaRepository;
            _notificacionRepository = notificacionRepository;
            _notificacionService = notificacionService;
            _mapper = mapper;
        }

        public ClienteDto Create(ClienteCreateRequest clienteCreateRequest)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateRequest);
            _clienteRepository.Add(cliente);
            return _mapper.Map<ClienteDto>(cliente);
        }

        public void Update(int id, ClienteUpdateRequest clienteUpdateRequest)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new NotFoundException($"No se encontró el cliente con el id {id}");

            _mapper.Map(clienteUpdateRequest, cliente);
            _clienteRepository.Update(cliente);
        }

        public void Delete(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new NotFoundException($"No se encontró el cliente con el id {id}");

            _clienteRepository.Delete(cliente);
        }
        public ClienteDto GetById(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new NotFoundException($"No se encontró el cliente con el id {id}");

            return _mapper.Map<ClienteDto>(cliente);
        }

        public List<ClienteDto> GetAll()
        {
            var clientes = _clienteRepository.GetAll();
            return _mapper.Map<List<ClienteDto>>(clientes);
        }


        public List<Cliente> GetClientsWithPets()
        {
            var clientes = _clienteRepository.GetClientsWithPets(c => c.Mascotas).ToList();
            return _mapper.Map<List<Cliente>>(clientes);
        }





        public void AsignarMascota(int clienteId, int mascotaId)
        {
            var cliente = _clienteRepository.GetById(clienteId);
            if (cliente == null)
                throw new NotFoundException($"No se encontró el cliente con el id {clienteId}");

            var mascota = _mascotaRepository.GetById(mascotaId);
            if (mascota == null)
                throw new NotFoundException($"No se encontró la mascota con el id {mascotaId}");

            // asociamos la mascota al cliente
            mascota.ClienteId = clienteId;
            _mascotaRepository.Update(mascota);
        }

        public ReservaDto CrearReserva(int mascotaId, ReservaCreateRequest reservaCreateRequest)
        {
            var mascota = _mascotaRepository.GetByIdWithCliente(mascotaId);
            if (mascota == null)
                throw new NotFoundException($"No se encontró la mascota con el id {mascotaId}");

            var guarderia = _guarderiaRepository.GetById(reservaCreateRequest.GuarderiaId);
            if (guarderia == null)
                throw new NotFoundException($"No se encontró la guardería con el id {reservaCreateRequest.GuarderiaId}");

            var nuevaReserva = _mapper.Map<Reserva>(reservaCreateRequest);
            nuevaReserva.GuarderiaId = reservaCreateRequest.GuarderiaId;
            nuevaReserva.MascotaId = mascotaId;
            nuevaReserva.TipoMascota = mascota.TipoMascota;

            _reservaRepository.Add(nuevaReserva);

            // envia notificacion al dueño
            _notificacionService.EnviarNotificacion(mascota.Cliente.Id, guarderia.DuenoId, reservaCreateRequest.Descripcion);

            var reservaDto = _mapper.Map<ReservaDto>(nuevaReserva);
            return reservaDto;
        }

        public void CancelarReserva(int reservaId)
        {
            var reserva = _reservaRepository.GetById(reservaId);
            if (reserva == null)
                throw new NotFoundException($"No se encontró la reserva con el id {reservaId}");

            reserva.Estado = EstadoReserva.Rechazada;
            _reservaRepository.Update(reserva);
        }

        public void EnviarMensajeAlDueno(int reservaId, string mensaje)
        {
            var notificacion = _notificacionRepository.GetById(reservaId);
            if (notificacion == null)
                throw new NotFoundException($"No se encontró la notificación con el id {reservaId}");

            notificacion.Mensaje = mensaje;
            _notificacionRepository.Update(notificacion);
        }

        public List<NotificacionDto> VerNotificaciones(int clienteId)
        {
            var notificaciones = _notificacionRepository.GetByUsuarioId(clienteId);
            return _mapper.Map<List<NotificacionDto>>(notificaciones);
        }
    }

}

