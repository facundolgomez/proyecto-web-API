using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;
        
        public string NombreUsuario { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        public List<MascotaDto> Mascotas { get; set; } = new List<MascotaDto>();

        public static ClienteDto Create(Cliente cliente)
        {
            var dto = new ClienteDto();
            dto.Id = cliente.Id;
            dto.Nombre = cliente.Nombre;
            dto.Apellido = cliente.Apellido;
            dto.NombreUsuario = cliente.NombreUsuario;
            dto.Email = cliente.Email;  
            dto.Direccion = cliente.Direccion;  
            dto.UserRole = cliente.UserRole;
            dto.Mascotas = cliente.Mascotas.Select(m => MascotaDto.Create(m)).ToList();

            return dto;
        }

        public static List<ClienteDto> CreateList(IEnumerable<Cliente> cliente)
        {
            List<ClienteDto> listDto = [];
            foreach (var s in cliente)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}