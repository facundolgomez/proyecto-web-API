using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class Guarderia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int DuenoId { get; set; }

        public  Dueno Dueno { get; set; } = new Dueno();    

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
