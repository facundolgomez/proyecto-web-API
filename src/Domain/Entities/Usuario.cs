using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public abstract class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Contrasena { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        public UserRole UserRole { get; set; }

        public  ICollection<Notificacion> NotificacionesEnviadas { get; set; } // Notificaciones que ha enviado
        public  ICollection<Notificacion> NotificacionesRecibidas { get; set; } // Notificaciones que ha recibido
    }

}

