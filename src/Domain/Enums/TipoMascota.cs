﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TipoMascota
    {
        [EnumMember(Value = "Gato")]
        Gato,

        [EnumMember(Value = "Perro")]
        Perro
    }
}
