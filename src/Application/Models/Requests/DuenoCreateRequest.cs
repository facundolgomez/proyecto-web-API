using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class DuenoCreateRequest
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string NombreUsuario { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

    }
}
