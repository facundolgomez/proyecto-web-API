using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mascota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Cliente Cliente { get; set; } //propiedad de navegacion,
                                             // permite acceder a la entidad Cliente
                                             //desde una instancia de mascota
        [Required]
        public string Nombre { get; set; } = string.Empty;  
       

        public int? ClienteId { get; set; }
        


        public TipoMascota TipoMascota { get; set; }

        public ICollection<Reserva> Reservas {  get; set; }    
    }
}

