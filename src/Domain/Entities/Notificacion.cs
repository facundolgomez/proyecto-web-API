using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notificacion
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaCreado { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
        
        public Reserva Reserva { get; set; }  
        public int ReservaId { get; set; }  

    }
}
