using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Application.Models
{
    public class GuarderiaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty ;

        public float PrecioPorHora { get; set; }   
        public int DuenoId { get; set; }
        
        public string DuenoNombre { get; set; } = string.Empty;
        
        public int CantidadReservas { get; set; }


        public static GuarderiaDto Create(Guarderia guarderia)
        {
            var dto = new GuarderiaDto();
            dto.Id = guarderia.Id;
            dto.Nombre = guarderia.Nombre;
            dto.Direccion = guarderia.Direccion;    
            dto.PrecioPorHora = guarderia.PrecioPorHora;
            dto.DuenoId = guarderia.DuenoId;
            dto.DuenoNombre = guarderia.Dueno != null ? $"{guarderia.Dueno.Nombre} {guarderia.Dueno.Apellido}" : string.Empty;
            dto.CantidadReservas = guarderia.Reservas.Count;    


            return dto;
        }

        public static List<GuarderiaDto> CreateList(IEnumerable<Guarderia> guarderias)
        {
            List<GuarderiaDto> listDto = [];
            foreach (var s in guarderias)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}