using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Models.Requests
{
    public class ReservaCreateRequest
    {
        
        public int GuarderiaId { get; set; }
        public int MascotaId { get; set; }
        public string Titulo { get; set; }  = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public TipoMascota TipoMascota { get; set; }
    }
}
