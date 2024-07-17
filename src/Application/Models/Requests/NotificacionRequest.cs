using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class NotificacionRequest
    {
        public string Mensaje { get; set; } = string.Empty;
        public int? NotificacionOriginalId { get; set; }
    }
}
