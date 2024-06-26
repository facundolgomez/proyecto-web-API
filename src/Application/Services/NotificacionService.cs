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
        
        public NotificacionDto EnviarNotificacion(int usuarioId, string mensaje)
        {
            var notificacion = new Notificacion
            {
                UsuarioId = usuarioId,
                Mensaje = mensaje,
                FechaCreado = DateTime.Now,
                EstadoReserva = EstadoReserva.Pendiente

            };

            _notificacionRepository.Add(notificacion);
            return _mapper.Map<NotificacionDto>(notificacion);
        }

        public void MarcarComoLeido(int notificacionId)
        {
            var notificacion = _notificacionRepository.GetById(notificacionId);
            if (notificacion != null)
            {
                notificacion.EstadoReserva = EstadoReserva.Pendiente;
                _notificacionRepository.Update(notificacion);
            }
        }
    }
}

