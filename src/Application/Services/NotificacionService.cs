using System;
using System.Collections.Generic;
using Application.Models;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Services
{
    public class NotificacionService : INotificacionService
    {
        private readonly INotificacionRepository _notificacionRepository;

        public NotificacionService(INotificacionRepository notificacionRepository)
        {
            _notificacionRepository = notificacionRepository;
        }

        public NotificacionDto EnviarNotificacion(int usuarioId, string mensaje)
        {
            var notificacion = new Notificacion
            {
                UsuarioId = usuarioId,
                Mensaje = mensaje,
                FechaCreado = DateTime.Now,
                
            };

            _notificacionRepository.Add(notificacion);
            return notificacion;
        }

        public void MarcarComoLeido(int notificacionId)
        {
            var notificacion = _notificacionRepository.GetById(notificacionId);
            if (notificacion != null)
            {
                notificacion.Leido = true;
                _notificacionRepository.Update(notificacion);
            }
        }
    }
}

