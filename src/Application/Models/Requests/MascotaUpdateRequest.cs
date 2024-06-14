using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Requests
{
    public class MascotaUpdateRequest
    {
        public string Nombre { get; set; } = string.Empty;

        public TipoMascota TipoMascota { get; set; }

    }
}