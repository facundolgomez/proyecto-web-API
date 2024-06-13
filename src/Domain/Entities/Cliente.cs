using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Cliente : Usuario
    {

        public Cliente()
        {
            UserRole = (UserRole.Cliente);
        }    
       public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();

    }

}