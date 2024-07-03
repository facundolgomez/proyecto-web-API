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
        
        public string NombreUsuario { get; set; } = string.Empty;
        
        public string Nombre { get; set; } = string.Empty;
        
        public string Apellido { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Contrasena { get; set; } = string.Empty;
        
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public UserRole UserRole { get; set; }
        public ICollection<Notificacion> Notificaciones { get; set; }






    }
}
