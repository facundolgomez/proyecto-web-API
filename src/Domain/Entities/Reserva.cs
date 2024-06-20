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
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Mascota Mascota { get; set; }
        public Guarderia Guarderia { get; set; } //propiedad de navegacion
        public int GuarderiaId { get; set; }
        public int MascotaId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoMascota TipoMascota { get; set; }
        public string Estado { get; set; }




    }
}
