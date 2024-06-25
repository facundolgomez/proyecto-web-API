using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Models
{
    public class NotificacionDto
    {
        public EstadoReserva EstadoReserva { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreado { get; set; }

        public static NotificacionDto Create(Notificacion notificacion)
        {
            var dto = new NotificacionDto();
            dto.EstadoReserva = notificacion.EstadoReserva;
            dto.UsuarioId = notificacion.UsuarioId; 
            dto.FechaCreado = notificacion.FechaCreado;

            return dto;
        }
    }
}
