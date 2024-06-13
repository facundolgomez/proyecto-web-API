using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class GuarderiaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        

        public static GuarderiaDto Create(Guarderia guarderia)
        {
            var dto = new GuarderiaDto();
            dto.Id = guarderia.Id;
            dto.Nombre = guarderia.Nombre;
            

            return dto;
        }

        public static List<GuarderiaDto> CreateList(IEnumerable<guarderia> guarderias)
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