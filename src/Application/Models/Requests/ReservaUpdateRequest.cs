using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Models.Requests
{
    public class ReservaUpdateRequest
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public TipoMascota TipoMascota { get; set; }
    }
}
