using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EstadoReserva
    {
        [EnumMember(Value = "Aprobada")]
        Aprobada,
        [EnumMember(Value = "Rechazada")]
        Rechazada,
        [EnumMember(Value = "Pendiente")]
        Pendiente
    }
}
