using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class DueñoCreateRequest
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Contraseña { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string NombreUsuario { get; set; } = string.Empty;

    }
}
