using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EstadoMensaje
    {
        [EnumMember(Value = "Pendiente")]
        Pendiente,
        [EnumMember(Value = "Leido")]
        Leido,
        [EnumMember(Value = "Respondido")]
        Respondido
    }
}
