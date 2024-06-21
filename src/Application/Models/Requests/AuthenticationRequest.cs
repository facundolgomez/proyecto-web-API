using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        public string? NombreUsuario { get; set; }
        [Required]
        public string? Contrasena { get; set; }
        public string? UserRole { get; set; }
    }
}
