using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dueno : Usuario
    {
        public ICollection<Guarderia> Guarderias { get; set; } = new List<Guarderia>();


    }

}