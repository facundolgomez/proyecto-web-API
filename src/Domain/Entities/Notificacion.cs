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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int RemitenteId { get; set; } // id del usuario que envia la notificacion
        public UserRole RemitenteRole { get; set; } // rol del usuario que envia la notificacion
      
        public int DestinatarioId { get; set; } // id del usuario que recibe la notificacion
        public UserRole DestinatarioRole { get; set; } // rol del usuario que recibe la notificacion
        
        public string Mensaje { get; set; }
        public DateTime FechaCreado { get; set; }
        public EstadoMensaje EstadoMensaje { get; set; }
        

        public Usuario Remitente { get; set; } // propiedad de navegación para el remitente
        public Usuario Destinatario { get; set; } // propiedad de navegación para el destinatario

        public Notificacion()
        {
            EstadoMensaje = EstadoMensaje.Pendiente;
        }
    }

}

