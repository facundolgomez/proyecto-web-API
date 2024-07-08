using Domain.Entities;
using Domain.Enums;
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
        public string NombreUsuario {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        


        public static DuenoDto Create(Dueno dueno)
        {
            var dto = new DuenoDto();
            dto.Id = dueno.Id;
            dto.Nombre = dueno.Nombre;
            dto.Apellido = dueno.Apellido;
            dto.NombreUsuario = dueno.NombreUsuario;    
            dto.Email = dueno.Email;
            dto.Direccion = dueno.Direccion;
            dto.UserRole = dueno.UserRole;
            

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
