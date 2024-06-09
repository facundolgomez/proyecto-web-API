using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DueñoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public static DueñoDto Create(Dueño dueño)
        {
            var dto = new DueñoDto();
            dto.Id = dueño.Id;
            dto.Nombre = dueño.Nombre;
            dto.Apellido = dueño.Apellido;

            return dto;
        }

        public static List<DueñoDto> CreateList(IEnumerable<Dueño> dueños)
        {
            List<DueñoDto> listDto = [];
            foreach (var s in dueños)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}
