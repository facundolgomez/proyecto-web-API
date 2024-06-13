using Domain.Entities;
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

        public static ClienteDto Create(Cliente cliente)
        {
            var dto = new ClienteDto();
            dto.Id = cliente.Id;
            dto.Nombre = cliente.Nombre;
            dto.Apellido = cliente.Apellido;

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