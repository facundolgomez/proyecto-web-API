using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Requests;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface INotificacionService 
    {
        public NotificacionDto EnviarNotificacion(int usuarioId, string mensaje);
        public void MarcarComoLeido(int notificacionId);
    }
}
