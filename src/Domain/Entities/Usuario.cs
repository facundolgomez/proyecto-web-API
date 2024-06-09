using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Key]
        [EmailAddress]
        public string Email { get; set; }
        

        public Usuario(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }



    }
}
