﻿using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public TipoMascota TipoMascota { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int GuarderiaId { get; set; }
        public int MascotaId { get; set; } 
        public string Titulo { get; set; }  
        public string Descripcion { get; set; } 
        public EstadoReserva Estado { get; set; }

        public static ReservaDto Create(Reserva reserva)
        {
            var dto = new ReservaDto();
            dto.Id = reserva.Id;
            dto.FechaDesde = reserva.FechaDesde;
            dto.FechaHasta = reserva.FechaHasta;
            dto.TipoMascota = reserva.Mascota.TipoMascota;
            dto.GuarderiaId = reserva.GuarderiaId;
            dto.MascotaId   = reserva.MascotaId;
            dto.Estado = reserva.Estado;
            return dto;
        }

        public static List<ReservaDto> CreateList(IEnumerable<Reserva> reservas)
        {
            List<ReservaDto> listDto = new List<ReservaDto>();
            foreach (var reserva in reservas)
            {
                listDto.Add(Create(reserva));
            }

            return listDto;
        }
    }
}