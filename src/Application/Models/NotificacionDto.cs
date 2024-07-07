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
        public int Id { get; set; }
        public DateTime FechaCreado { get; set; }
        public string Mensaje { get; set; } 

        public static NotificacionDto Create(Notificacion notificacion)
        {
            var dto = new NotificacionDto();
            dto.Id = notificacion.Id;
            dto.FechaCreado = notificacion.FechaCreado;
            dto.Mensaje = notificacion.Mensaje; 
            

            return dto;
        }
    }
}
