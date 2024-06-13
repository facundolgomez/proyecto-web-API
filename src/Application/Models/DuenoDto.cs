using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DuenoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public static DuenoDto Create(Dueno dueno)
        {
            var dto = new DuenoDto();
            dto.Id = dueno.Id;
            dto.Nombre = dueno.Nombre;
            dto.Apellido = dueno.Apellido;

            return dto;
        }

        public static List<DuenoDto> CreateList(IEnumerable<Dueno> duenos)
        {
            List<DuenoDto> listDto = [];
            foreach (var s in duenos)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}
