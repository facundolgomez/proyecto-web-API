using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Models
{
    public class MascotaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public TipoMascota TipoMascota { get; set; }

        public List<ReservaDto> Reservas { get; set; } = new List<ReservaDto>();


        public static MascotaDto Create(Mascota mascota)
        {
            var dto = new MascotaDto();
            dto.Id = mascota.Id;
            dto.Nombre = mascota.Nombre;
            dto.TipoMascota = mascota.TipoMascota;
            dto.Reservas = mascota.Reservas.Select(r => ReservaDto.Create(r)).ToList();


            return dto;
        }

        public static List<MascotaDto> CreateList(IEnumerable<Mascota> mascotas)
        {
            List<MascotaDto> listDto = [];
            foreach (var s in mascotas)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}
