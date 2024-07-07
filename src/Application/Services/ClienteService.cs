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
        private readonly GenericService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto> _genericService;
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IRepository<Reserva> _reservaRepository;
        private readonly IRepository<Guarderia> _guarderiaRepository;
        private readonly INotificacionRepository _notificacionRepository;
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        public ClienteService(IRepository<Cliente> repository, IMascotaRepository mascotaRepository,
            IRepository<Reserva> reservaRepository, INotificacionRepository notificacionRepository, INotificacionService notificacionService, IRepository<Guarderia> guarderiaRepository, IMapper mapper)
        {
            _genericService = new GenericService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto>(repository, mapper);
            _mascotaRepository = mascotaRepository;
            _reservaRepository = reservaRepository;
            _notificacionRepository = notificacionRepository;
            _notificacionService = notificacionService; 
            _guarderiaRepository = guarderiaRepository; 
            _mapper = mapper;
        }


        public ClienteDto Create(ClienteCreateRequest clienteCreateRequest)
        {
            return _genericService.Create(clienteCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<ClienteDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Cliente> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public ClienteDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, ClienteUpdateRequest clienteUpdateRequest)
        {
            _genericService.Update(id, clienteUpdateRequest);
        }

        //aca arrancan los metodos especificos (no genericos) de la entidad Cliente
        public void AsignarMascota(int clienteId, int mascotaId)
        {
            var cliente = _genericService.GetById(clienteId);
            if (cliente == null)
                throw new NotFoundException($"No se encontro el cliente con el id {clienteId}");

            var mascota = _mascotaRepository.GetById(mascotaId);
            if (mascota == null)
                throw new NotFoundException($"No se encontro la mascota con el id {mascotaId}");

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

           
            
            // notificamos al Dueno

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
            {
                throw new NotFoundException($"No se encontró la notificacion con el id {reservaId}");

            }
            
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

