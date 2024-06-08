using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : Usuario
    {
        public Cliente(string nombre, string apellido, string email) : base(nombre, apellido, email)
        {

        }
    }

}