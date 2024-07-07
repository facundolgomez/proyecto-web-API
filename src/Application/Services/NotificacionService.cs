using System;
using System.Collections.Generic;
using Application.Models;
using Domain.Entities;
using Application.Interfaces;
using AutoMapper;
using Domain.Enums;

namespace Application.Services
{
    public class NotificacionService : INotificacionService
    {
        private readonly INotificacionRepository _notificacionRepository;
        private readonly IMapper _mapper;

        public NotificacionService(INotificacionRepository notificacionRepository, IMapper mapper)
        {
            _notificacionRepository = notificacionRepository;
            _mapper = mapper;   
        }

        public void EnviarNotificacion(int clienteId, int duenoGuarderiaId, string mensaje)
        {
            var notificacion = new Notificacion
            {
                RemitenteId = clienteId,
                RemitenteRole = UserRole.Cliente,
                DestinatarioId = duenoGuarderiaId,
                DestinatarioRole = UserRole.Dueno,
                Mensaje = mensaje,
                FechaCreado = DateTime.Now,
            };

            _notificacionRepository.Add(notificacion);
        }

        public void MarcarComoLeido(int notificacionId)
        {
            var notificacion = _notificacionRepository.GetById(notificacionId);
            if (notificacion != null)
            {
                notificacion.EstadoMensaje = EstadoMensaje.Leido;
                _notificacionRepository.Update(notificacion);
            }
        }







    }
}

